using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LacysMobile.Web.Helpers
{
    public class SelectListItemHelper
    {
        public static IEnumerable<SelectListItem> GetStateList()
        {
            IList<SelectListItem> states = new List<SelectListItem>
            {
                new SelectListItem() {Text="Alabama", Value="AL"},
                new SelectListItem() { Text="Alaska", Value="AK"},
                new SelectListItem() { Text="Arizona", Value="AZ"},
                new SelectListItem() { Text="Arkansas", Value="AR"},
                new SelectListItem() { Text="California", Value="CA"},
                new SelectListItem() { Text="Colorado", Value="CO"},
                new SelectListItem() { Text="Connecticut", Value="CT"},
                new SelectListItem() { Text="District of Columbia", Value="DC"},
                new SelectListItem() { Text="Delaware", Value="DE"},
                new SelectListItem() { Text="Florida", Value="FL"},
                new SelectListItem() { Text="Georgia", Value="GA"},
                new SelectListItem() { Text="Hawaii", Value="HI"},
                new SelectListItem() { Text="Idaho", Value="ID"},
                new SelectListItem() { Text="Illinois", Value="IL"},
                new SelectListItem() { Text="Indiana", Value="IN"},
                new SelectListItem() { Text="Iowa", Value="IA"},
                new SelectListItem() { Text="Kansas", Value="KS"},
                new SelectListItem() { Text="Kentucky", Value="KY"},
                new SelectListItem() { Text="Louisiana", Value="LA"},
                new SelectListItem() { Text="Maine", Value="ME"},
                new SelectListItem() { Text="Maryland", Value="MD"},
                new SelectListItem() { Text="Massachusetts", Value="MA"},
                new SelectListItem() { Text="Michigan", Value="MI"},
                new SelectListItem() { Text="Minnesota", Value="MN"},
                new SelectListItem() { Text="Mississippi", Value="MS"},
                new SelectListItem() { Text="Missouri", Value="MO"},
                new SelectListItem() { Text="Montana", Value="MT"},
                new SelectListItem() { Text="Nebraska", Value="NE"},
                new SelectListItem() { Text="Nevada", Value="NV"},
                new SelectListItem() { Text="New Hampshire", Value="NH"},
                new SelectListItem() { Text="New Jersey", Value="NJ"},
                new SelectListItem() { Text="New Mexico", Value="NM"},
                new SelectListItem() { Text="New York", Value="NY"},
                new SelectListItem() { Text="North Carolina", Value="NC"},
                new SelectListItem() { Text="North Dakota", Value="ND"},
                new SelectListItem() { Text="Ohio", Value="OH"},
                new SelectListItem() { Text="Oklahoma", Value="OK"},
                new SelectListItem() { Text="Oregon", Value="OR"},
                new SelectListItem() { Text="Pennsylvania", Value="PA"},
                new SelectListItem() { Text="Rhode Island", Value="RI"},
                new SelectListItem() { Text="South Carolina", Value="SC"},
                new SelectListItem() { Text="South Dakota", Value="SD"},
                new SelectListItem() { Text="Tennessee", Value="TN"},
                new SelectListItem() { Text="Texas", Value="TX"},
                new SelectListItem() { Text="Utah", Value="UT"},
                new SelectListItem() { Text="Vermont", Value="VT"},
                new SelectListItem() { Text="Virginia", Value="VA"},
                new SelectListItem() { Text="Washington", Value="WA"},
                new SelectListItem() { Text="West Virginia", Value="WV"},
                new SelectListItem() { Text="Wisconsin", Value="WI"},
                new SelectListItem() { Text="Wyoming", Value="WY"}
            };
            return states;
        }

        public static IEnumerable<SelectListItem> GetCardTypeList()
        {
            IList<SelectListItem> cardTypes = new List<SelectListItem>
            {
                new SelectListItem() {Text="Lacy's", Value="lacys"},
                new SelectListItem() {Text="Lacy's American Express", Value="lacysAmericanExpress"},
                new SelectListItem() {Text="American Express", Value="AmericanExpress"},
                new SelectListItem() {Text="Visa", Value="visa"},
                new SelectListItem() {Text="MasterCard", Value="masterCard"},
                new SelectListItem() {Text="Discover", Value="discover"}            
            };
            return cardTypes;
        }

        public static IEnumerable<SelectListItem> GetExpiryMonthList()
        {
            IList<SelectListItem> expiryMonthList = new List<SelectListItem>
            {
                new SelectListItem() {Text="January", Value="1"},
                new SelectListItem() {Text="February", Value="2"},
                new SelectListItem() {Text="March", Value="3"},
                new SelectListItem() {Text="April", Value="4"},
                new SelectListItem() {Text="May", Value="5"},
                new SelectListItem() {Text="June", Value="6"},   
                new SelectListItem() {Text="July", Value="7"},
                new SelectListItem() {Text="August", Value="8"},
                new SelectListItem() {Text="September", Value="9"},
                new SelectListItem() {Text="October", Value="10"},
                new SelectListItem() {Text="November", Value="11"},
                new SelectListItem() {Text="December", Value="12"}  
            };
            return expiryMonthList;
        }

        public static IEnumerable<SelectListItem> GetExpiryYearList()
        {
            IList<SelectListItem> expiryYearList = new List<SelectListItem>
            {
                new SelectListItem() {Text="2014", Value="2014"},
                new SelectListItem() {Text="2015", Value="2015"},
                new SelectListItem() {Text="2016", Value="2016"},
                new SelectListItem() {Text="2017", Value="2017"},
                new SelectListItem() {Text="2018", Value="2018"},
                new SelectListItem() {Text="2019", Value="2019"},
                new SelectListItem() {Text="2020", Value="2020"},
                new SelectListItem() {Text="2021", Value="2021"},
                new SelectListItem() {Text="2022", Value="2022"},
                new SelectListItem() {Text="2023", Value="2023"},
            };
            return expiryYearList;
        }
    }
}