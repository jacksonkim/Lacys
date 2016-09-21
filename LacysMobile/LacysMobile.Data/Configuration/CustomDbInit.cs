using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using LacysMobile.Models;

namespace LacysMobile.Data.Configuration
{
    class CustomDbInit : DropCreateDatabaseIfModelChanges<DataContext>
    {
        private Random random = new Random();

        protected override void Seed(DataContext context)
        {
            #region "seed products"
            for (int i = 1; i < 7; i++)
			{
			    Product product = new Product();
                switch (i)
                {
                    case 1:
                        product.Name = "Women's Front-Cross Slim Dress";
                        product.Description = "This sweet slim dress features flattering front detail and a slimming lining to create a smooth silhouette.";
                        break;
                    case 2:
                        product.Name = "Women's Sleeveless Polka-dot Dress";
                        product.Description = "The polka-dot print keep things playful, which includes a belt that adds polish.";
                        break;
                    case 3:
                        product.Name = "Women's Petite Navy Dress";
                        product.Description = "Pretty petite dress with a sophisticated party style.";
                        break;
                    case 4:
                        product.Name = "Women's Business Casual Dress";
                        product.Description = "Rare edition checkered dress for any business occasion with quarter sleeves.";
                        break;
                    case 5:
                        product.Name = "Women's Long-Sleeve Printed-Faux Dress";
                        product.Description = "With a vibrant print and flattering neckline, this dress takes you from desk to dinner in sophisticated style.";
                        break;
                    default:
                        product.Name = "Women's Short-Sleeve Belted Sweater Dress";
                        product.Description = "A look for all seasons, this light weight sweaterdress is a perfect find!";
                        break;
                }
                product.ItemType = "WomenDress";
                product.WarehousePrice = 25.00M;
                product.SellingPrice = (decimal)Math.Round(RandomNumberBetween(10.41, 100.50),2);
                if (i % 2 != 0)
                {
                    product.IsSpecial = false;
                    product.IsNew = true;
                }
                else
                {
                    product.IsSpecial = true;
                    product.IsNew = false;
                }
                product.ImageName = "womensDress" + i;

                context.Products.Add(product);
			}



            for (int i = 1; i < 7; i++)
            {
                Product product = new Product();
                switch (i)
                {
                    case 1:
                        product.Name = "Women's Pleated Belt French Coat";
                        product.Description = "High fashion collar and a fierce animal-print lining add fashion flair.";
                        break;
                    case 2:
                        product.Name = "Women's Seamed Leather Coat";
                        product.Description = "Thanks to flattering seamed details and buttery-soft leather, this coat is a must-have item of the season!";
                        break;
                    case 3:
                        product.Name = "Women's Hooded Trench Coat";
                        product.Description = "Update your outerwear wardrobe with this versatile trench coat featuring a removable hood.";
                        break;
                    case 4:
                        product.Name = "Women's Belted Trench Coat";
                        product.Description = "Update your wardrobe with this timeless trench coat featuring a flattering belted silhouette.";
                        break;
                    case 5:
                        product.Name = "Women's London Fog Hooded Rain Coat";
                        product.Description = "This versatile raincoat offers a removable hood and a flattering belted silhouette so you can look fabulous, no matter the weather!";
                        break;
                    default:
                        product.Name = "Women's Seamed-Zip-Front Coat";
                        product.Description = "Amp up your outerwear wardrobe with this edgy jacket!";
                        break;
                }
                product.ItemType = "WomenCoats";
                product.WarehousePrice = 25.00M;
                product.SellingPrice = (decimal)Math.Round(RandomNumberBetween(10.41, 100.50), 2);
                if (i % 2 != 0)
                {
                    product.IsSpecial = true;
                    product.IsNew = false;
                }
                else
                {
                    product.IsSpecial = false;
                    product.IsNew = true;
                }
                product.ImageName = "womensCoat" + i;

                context.Products.Add(product);
            }

            for (int i = 1; i < 7; i++)
            {
                Product product = new Product();
                switch (i)
                {
                    case 1:
                        product.Name = "Men's Dockers Straight Fit Pants";
                        product.Description = "Dockers' sturdy cotton in a straight fit.";
                        break;
                    case 2:
                        product.Name = "Men's Dockers Classic-Fit Khaki Pleated Pants";
                        product.Description = "For work and beyond: offering a comfortable fit that's perfect for casual Friday's and weekends alike.";
                        break;
                    case 3:
                        product.Name = "Men's Izod Golf Pants";
                        product.Description = "These are no ordinary pants. These Izod 100% cotton pants are perfect for spring and summer. ";
                        break;
                    case 4:
                        product.Name = "Men's Big and Tall Signature Kahki Pants";
                        product.Description = "Verstile enough to complement both your workweek and weekend wardrobes.";
                        break;
                    case 5:
                        product.Name = "Men's Dockers Relaxed Fit Never-Iron Pants";
                        product.Description = "In addition to the famous Dockers fit, these khakis were designed to be wrinkle free.";
                        break;
                    default:
                        product.Name = "Men's Classic-Fit Easy Refined Flat Front Pants";
                        product.Description = "Classic pants for the classic gentleman: for work and beyond.";
                        break;
                }
                product.ItemType = "MensPants";
                product.WarehousePrice = 25.00M;
                product.SellingPrice = (decimal)Math.Round(RandomNumberBetween(10.41, 100.50), 2);
                if (i % 2 != 0)
                {
                    product.IsSpecial = false;
                    product.IsNew = true;
                }
                else
                {
                    product.IsSpecial = true;
                    product.IsNew = false;
                }
                product.ImageName = "mensPants" + i;

                context.Products.Add(product);
            }


            for (int i = 1; i < 7; i++)
            {
                Product product = new Product();
                switch (i)
                {
                    case 1:
                        product.Name = "Men's Elmwood Down Jacket";
                        product.Description = "Durable Elwood designed jacket with a detachable hood and filled with ultra-warm blend of down and feathers.";
                        break;
                    case 2:
                        product.Name = "Men's North Face Jacket";
                        product.Description = "Whether rain or snow or sleet, you'll stay super warm in this insulated jacket from the North Face.";
                        break;
                    case 3:
                        product.Name = "Men's Outfitter Down Solid Puffer Coat";
                        product.Description = "For warmth without the weight, this Outfitter down-filled coat is perfect for layering when the weather gets cold. ";
                        break;
                    case 4:
                        product.Name = "Men's Denali Fleece Jacket";
                        product.Description = "Perfect on its own or zipped into a shell jacket, the Denali jacket for men guards you from the chill with fleece and a durable design that will last season after season.";
                        break;
                    case 5:
                        product.Name = "Men's Zip Front Jacket";
                        product.Description = "Get up and get out in style with this jacket from our personal designer.";
                        break;
                    default:
                        product.Name = "Men's London Fog Coat";
                        product.Description = "Invest in the timeless tradition of classic design with this iconic coat from London Fog.";
                        break;
                }
                product.ItemType = "MenCoats";
                product.WarehousePrice = 25.00M;
                product.SellingPrice = (decimal)Math.Round(RandomNumberBetween(10.41, 100.50), 2);
                if (i % 2 != 0)
                {
                    product.IsSpecial = false;
                    product.IsNew = true;
                }
                else
                {
                    product.IsSpecial = true;
                    product.IsNew = false;
                }
                product.ImageName = "mensCoat" + i;

                context.Products.Add(product);
            }


            for (int i = 1; i < 7; i++)
            {
                Product product = new Product();
                switch (i)
                {
                    case 1:
                        product.Name = "Coach Legacy Signature Slim Zip Bag";
                        product.Description = "Crafted in hand-worked leather, this shoulder bag has a beautifully organized interior.";
                        break;
                    case 2:
                        product.Name = "Dooney & Bourke Canvas Handbag";
                        product.Description = "Breeze into the new season with this sleek shopper cut from crisp nylon with rich leather trim.";
                        break;
                    case 3:
                        product.Name = "Ralph Lauren East West Tote";
                        product.Description = "Your classic carryall rendered in faux leather with signature detailing. ";
                        break;
                    case 4:
                        product.Name = "Calvin Klein Saffiano Satchel";
                        product.Description = "Give your look polished perfection with this refined satchel from Calvin Klein.";
                        break;
                    case 5:
                        product.Name = "Michael Kors Sutton Large Satchel";
                        product.Description = "Wherever your travels may take you, this tote makes for a refined companion.";
                        break;
                    default:
                        product.Name = "Hamilton Saffiano Leather Tote";
                        product.Description = "Soft leather and luxurious golden hardware grace this gorgeous design from Michael Kors.";
                        break;
                }
                product.ItemType = "Handbags";
                product.WarehousePrice = 25.00M;
                product.SellingPrice = (decimal)Math.Round(RandomNumberBetween(100.20, 500.50), 2);
                if (i % 2 != 0)
                {
                    product.IsSpecial = false;
                    product.IsNew = true;
                }
                else
                {
                    product.IsSpecial = true;
                    product.IsNew = false;
                }
                product.ImageName = "handbags" + i;

                context.Products.Add(product);
            }

            for (int i = 1; i < 7; i++)
            {
                Product product = new Product();
                switch (i)
                {
                    case 1:
                        product.Name = "Prada Sunglasses";
                        product.Description = "The hallmark styling of this world-renowned fashion leader denotes high quality and a stong tradition of craftmanship.";
                        break;
                    case 2:
                        product.Name = "Maui Jim Sunglasses";
                        product.Description = "Featuring exclusive evolution single gradient lenses in bronze, perfect for those with smaller facial features.";
                        break;
                    case 3:
                        product.Name = "Oakley Sunglasses";
                        product.Description = "Looking good while playing hard is easier than ever. These embody the power and beauty of Oakley women.";
                        break;
                    case 4:
                        product.Name = "Ray-Ban Sunglasses";
                        product.Description = "Ray-Ban is the brand of sunglasses preferred by true individuals worldwide.";
                        break;
                    case 5:
                        product.Name = "Tory Burch Sunglasses";
                        product.Description = "Imagine stylish textures and unique elements. Hand crafted originality and premium product.";
                        break;
                    default:
                        product.Name = "Persol Sunglasses";
                        product.Description = "Designed and crafted in Italy. A favorite among celebrities.";
                        break;
                }
                product.ItemType = "Sunglasses";
                product.WarehousePrice = 25.00M;
                product.SellingPrice = (decimal)Math.Round(RandomNumberBetween(100.20, 500.50), 2);
                if (i % 2 != 0)
                {
                    product.IsSpecial = false;
                    product.IsNew = true;
                }
                else
                {
                    product.IsSpecial = true;
                    product.IsNew = false;
                }
                product.ImageName = "sunglasses" + i;

                context.Products.Add(product);
            }
            #endregion

            #region "seed feedbacks"
            Feedback feedback = new Feedback{
                FirstName = "Edward",
                LastName = "ScissorHands",
                Email = "Edward@aol.com",
                Comments = "I liked your website very much.",
                FeedbackDate = Convert.ToDateTime("2009-05-08")
            };

            Feedback feedback1 = new Feedback
            {
                FirstName = "Wolverine",
                LastName = "Logan",
                Email = "Wolverine@aol.com",
                Comments = "Speedy shipping and great customer service.",
                FeedbackDate = Convert.ToDateTime("2012-01-21")
            };

            Feedback feedback2 = new Feedback
            {
                FirstName = "Kevin",
                LastName = "Costner",
                Email = "Kevin@aol.com",
                Comments = "It's nice to depend on a store that makes quality products.",
                FeedbackDate = Convert.ToDateTime("2013-04-15")
            };

            Feedback feedback3 = new Feedback
            {
                FirstName = "Harry",
                LastName = "Chin",
                Email = "Harry@aol.com",
                Comments = "Very nice website.",
                FeedbackDate = Convert.ToDateTime("2014-02-02")
            };

            context.Feedback.Add(feedback);
            context.Feedback.Add(feedback1);
            context.Feedback.Add(feedback2);
            context.Feedback.Add(feedback3);
            #endregion

            base.Seed(context);
        }

        private double RandomNumberBetween(double minValue, double maxValue)
        {
            var next = random.NextDouble();

            return minValue + (next * (maxValue - minValue));
        }

    }
}
