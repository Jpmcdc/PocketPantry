using System;
using System.Collections.Generic;
using Pocket_Pantry.ViewModels;
using Pocket_Pantry.Models;

using Xamarin.Forms;
using SQLite;
using Xamarin.Forms.Xaml;
using Plugin.Media.Abstractions;
using Plugin.Media;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json;
using System.Linq;

namespace Pocket_Pantry
     
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class New_Recipe : ContentPage
    {

        /**
         *  This list will hold all the recipes
         */
        //public IList<Recipe> Recipes_List { get; private set; }

        /**
         *  New_Recipe Constructor
         */
        public New_Recipe()
        {
            InitializeComponent();
            //BindingContext = new RecipeViewModel();
        }

        /**
         *  Handles "Back" button
         *  Navigates to the previous page
         */
        async void cancel_btn(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        async void Save_Clicked(System.Object sender, System.EventArgs e)
        {
            // add the new recipe using Recipe
            Recipe newRecipe = new Recipe();
            {
                newRecipe.title = Entry_Title.Text;
                newRecipe.ingredients = Entry_Ingredients.Text;
                newRecipe.directions = Entry_Directions.Text;
            };

            //connection to the datbase & saving information
            SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation);
            conn.CreateTable<Recipe>();
            int rows = conn.Insert(newRecipe);
            conn.Close();

            if (rows > 0)
            {
                //_ = DisplayAlert("Success: ", "Recipe succesfully inserter", "OK");
                await Navigation.PopModalAsync();
            }
            else
                //_ = DisplayAlert("Failure: ", "Recipe failed to be inserter", "OK");
                await Navigation.PopModalAsync();
        }

        /*
         * This scans an image an gets the text to the title field
         */
        private void Scan_Title_Clicked(object sender, EventArgs e)
        {
            Recognize_Text();
        }


        /*
         * This is the function to recognize text form a image
         */
        private async void Recognize_Text()
        {
            //Here is where choosen image is saved
            MediaFile file = null;

            try
            {
                //Getting permissions to the storage
                await CrossMedia.Current.Initialize();

                //Checking if picking picture function is available
                if (!CrossMedia.Current.IsPickPhotoSupported)
                {
                    await DisplayAlert("Not able to pick photo", "Could not make it.", "OK");
                    return;
                }

                //Choosing picture
                file = await CrossMedia.Current.PickPhotoAsync();

                //Checking if a picture was choosen
                if (file == null)
                {
                    await DisplayAlert("Could not load Image", "Try Again", "OK");
                    return;
                }

                //Img is a xamarin image tag. Here I am just loading the choosen image to that tag
                //Img.Source = ImageSource.FromStream(() => file.GetStream());
            }
            catch (Exception exception)
            {
                await DisplayAlert("Access Denied", "Camera Access.\n" + exception.Message, "OK");
            }


            /*
             * Here is where the recognition starts
             */

            //this will be pass as an argument to the API
            byte[] imageAsBytes;

            using (var memoryStream = new MemoryStream())
            {
                file.GetStream().CopyTo(memoryStream);
                file.Dispose();
                imageAsBytes = memoryStream.ToArray();
            }

            //Creating a HTTPClient to make request to the API
            var client = new HttpClient();
            //Setting the content to be sent to the API
            var httpContent = new MultipartFormDataContent();
            //httpContent.Headers.ContentType.MediaType = "multipart/form-data";
            httpContent.Add(new StringContent("5c3aca107b88957"), "apikey"); //This is a special key needed to use the API
            httpContent.Add(new ByteArrayContent(imageAsBytes, 0, imageAsBytes.Length), "image", "image.jpg");

            //Sending the request to the API
            HttpResponseMessage response = await client.PostAsync("https://api.ocr.space/parse/image", httpContent); // This is the API URL

            //Checking if the response is OK
            if (response.IsSuccessStatusCode)
            {
                //Reading the content of the response
                string content = await response.Content.ReadAsStringAsync();

                //This is a class created below just to organize the reponse
                ORC ocrResult = JsonConvert.DeserializeObject<ORC>(content);


                if (ocrResult.OCRExitCode == 1)
                {
                    for (int i = 0; i < ocrResult.ParsedResults.Count(); i++)
                    {
                        //LblResult is a xamarin tag <Editor>. Setting the text to the editor
                        Entry_Title.Text += ocrResult.ParsedResults[i].ParsedText;
                    }
                }
                else
                {
                    //If any error, show it in an alert
                    await DisplayAlert("Http Error", "Error:\n" + content, "OK");
                }
            }
            else
            {
                //If any error with the response, show it in the <Editor>
                await DisplayAlert("Http Error", "Error:\n", "OK");
                //LblResult.Text = "Error HttpRequest";
            }
        }
    }
}
