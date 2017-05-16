using System.Collections.Generic;

namespace PicTalk.Droid.Models
{
    public class NavigationCatagoriesList
    {
        public string CatagoryCount { get; set; }
        public string CatagoryName { get; set; }
        public int CatagoryArrow { get; set; }


        public static List<NavigationCatagoriesList> GetNavCatagoryList()
        {
            List<NavigationCatagoriesList> NavCatList = new List<NavigationCatagoriesList>();
            NavCatList.Add(new NavigationCatagoriesList
            {
                //CatagoryCount = "10",
                CatagoryName = "Settings",
                CatagoryArrow = Resource.Mipmap.ic_arrow_forward

            });
            NavCatList.Add(new NavigationCatagoriesList
            {
                //CatagoryCount = "1",
                CatagoryName = "About",
                CatagoryArrow = Resource.Mipmap.ic_arrow_forward

            });
            NavCatList.Add(new NavigationCatagoriesList
            {
                //CatagoryCount = "12",
                CatagoryName = "Contact Us",
                CatagoryArrow = Resource.Mipmap.ic_arrow_forward

            });
            return NavCatList;
        }
    }
}