using System;
namespace Pocket_Pantry.Models
{
    public class Pantry_PocketModel
    {
        public string Name { get; set; }
        public string Detail { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
        public string Ingredients { get; set; }

        internal object ToLower()
        {
            throw new NotImplementedException();
        }
    }
}
