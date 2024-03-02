﻿using Microsoft.EntityFrameworkCore;
using ProductManagementService.Models;

namespace ProductManagementService.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> op) : DbContext(op)
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for Product
            #region
            modelBuilder.Entity<Country>().HasData(
                new Country { Id = 1, Name = "United States" },
                new Country { Id = 2, Name = "Afghanistan" },
                new Country { Id = 3, Name = "Albania" },
                new Country { Id = 4, Name = "Algeria" },
                new Country { Id = 5, Name = "American Samoa" },
                new Country { Id = 6, Name = "Andorra" },
                new Country { Id = 7, Name = "Angola" },
                new Country { Id = 8, Name = "Anguilla" },
                new Country { Id = 9, Name = "Antarctica" },
                new Country { Id = 10, Name = "Antigua And Barbuda" },
                new Country { Id = 11, Name = "Argentina" },
                new Country { Id = 12, Name = "Armenia" },
                new Country { Id = 13, Name = "Aruba" },
                new Country { Id = 14, Name = "Australia" },
                new Country { Id = 15, Name = "Austria" },
                new Country { Id = 16, Name = "Azerbaijan" },
                new Country { Id = 17, Name = "Bahamas" },
                new Country { Id = 18, Name = "Bahrain" },
                new Country { Id = 19, Name = "Bangladesh" },
                new Country { Id = 20, Name = "Barbados" },
                new Country { Id = 21, Name = "Belarus" },
                new Country { Id = 22, Name = "Belgium" },
                new Country { Id = 23, Name = "Belize" },
                new Country { Id = 24, Name = "Benin" },
                new Country { Id = 25, Name = "Bermuda" },
                new Country { Id = 26, Name = "Bhutan" },
                new Country { Id = 27, Name = "Bolivia" },
                new Country { Id = 28, Name = "Bosnia And Herzegowina" },
                new Country { Id = 29, Name = "Botswana" },
                new Country { Id = 30, Name = "Bouvet Island" },
                new Country { Id = 31, Name = "Brazil" },
                new Country { Id = 32, Name = "British Indian Ocean Territory" },
                new Country { Id = 33, Name = "Brunei Darussalam" },
                new Country { Id = 34, Name = "Bulgaria" },
                new Country { Id = 35, Name = "Burkina Faso" },
                new Country { Id = 36, Name = "Burundi" },
                new Country { Id = 37, Name = "Cambodia" },
                new Country { Id = 38, Name = "Cameroon" },
                new Country { Id = 39, Name = "Canada" },
                new Country { Id = 40, Name = "Cape Verde" },
                new Country { Id = 41, Name = "Cayman Islands" },
                new Country { Id = 42, Name = "Central African Republic" },
                new Country { Id = 43, Name = "Chad" },
                new Country { Id = 44, Name = "Chile" },
                new Country { Id = 45, Name = "China" },
                new Country { Id = 46, Name = "Christmas Island" },
                new Country { Id = 47, Name = "Cocos (Keeling) Islands" },
                new Country { Id = 48, Name = "Colombia" },
                new Country { Id = 49, Name = "Comoros" },
                new Country { Id = 50, Name = "Congo" },
                new Country { Id = 51, Name = "Cook Islands" },
                new Country { Id = 52, Name = "Costa Rica" },
                new Country { Id = 53, Name = "Cote D'Ivoire" },
                new Country { Id = 54, Name = "Croatia (Local Name: Hrvatska)" },
                new Country { Id = 55, Name = "Cuba" },
                new Country { Id = 56, Name = "Cyprus" },
                new Country { Id = 57, Name = "Czech Republic" },
                new Country { Id = 58, Name = "Denmark" },
                new Country { Id = 59, Name = "Djibouti" },
                new Country { Id = 60, Name = "Dominica" },
                new Country { Id = 61, Name = "Dominican Republic" },
                new Country { Id = 62, Name = "East Timor" },
                new Country { Id = 63, Name = "Ecuador" },
                new Country { Id = 64, Name = "Egypt" },
                new Country { Id = 65, Name = "El Salvador" },
                new Country { Id = 66, Name = "Equatorial Guinea" },
                new Country { Id = 67, Name = "Eritrea" },
                new Country { Id = 68, Name = "Estonia" },
                new Country { Id = 69, Name = "Ethiopia" },
                new Country { Id = 70, Name = "Falkland Islands (Malvinas)" },
                new Country { Id = 71, Name = "Faroe Islands" },
                new Country { Id = 72, Name = "Fiji" },
                new Country { Id = 73, Name = "Finland" },
                new Country { Id = 74, Name = "France" },
                new Country { Id = 75, Name = "French Guiana" },
                new Country { Id = 76, Name = "French Polynesia" },
                new Country { Id = 77, Name = "French Southern Territories" },
                new Country { Id = 78, Name = "Gabon" },
                new Country { Id = 79, Name = "Gambia" },
                new Country { Id = 80, Name = "Georgia" },
                new Country { Id = 81, Name = "Germany" },
                new Country { Id = 82, Name = "Ghana" },
                new Country { Id = 83, Name = "Gibraltar" },
                new Country { Id = 84, Name = "Greece" },
                new Country { Id = 85, Name = "Greenland" },
                new Country { Id = 86, Name = "Grenada" },
                new Country { Id = 87, Name = "Guadeloupe" },
                new Country { Id = 88, Name = "Guam" },
                new Country { Id = 89, Name = "Guatemala" },
                new Country { Id = 90, Name = "Guinea" },
                new Country { Id = 91, Name = "Guinea-Bissau" },
                new Country { Id = 92, Name = "Guyana" },
                new Country { Id = 93, Name = "Haiti" },
                new Country { Id = 94, Name = "Honduras" },
                new Country { Id = 95, Name = "Hong Kong" },
                new Country { Id = 96, Name = "Hungary" },
                new Country { Id = 97, Name = "Icel And" },
                new Country { Id = 98, Name = "India" },
                new Country { Id = 99, Name = "Indonesia" },
                new Country { Id = 100, Name = "Iran (Islamic Republic Of)" },
                new Country { Id = 101, Name = "Iraq" },
                new Country { Id = 102, Name = "Ireland" },
                new Country { Id = 103, Name = "Israel" },
                new Country { Id = 104, Name = "Italy" },
                new Country { Id = 105, Name = "Jamaica" },
                new Country { Id = 106, Name = "Japan" },
                new Country { Id = 107, Name = "Jordan" },
                new Country { Id = 108, Name = "Kazakhstan" },
                new Country { Id = 109, Name = "Kenya" },
                new Country { Id = 110, Name = "Kiribati" },
                new Country { Id = 111, Name = "Korea" },
                new Country { Id = 112, Name = "Kuwait" },
                new Country { Id = 113, Name = "Kyrgyzstan" },
                new Country { Id = 114, Name = "Lao People'S Dem Republic" },
                new Country { Id = 115, Name = "Latvia" },
                new Country { Id = 116, Name = "Lebanon" },
                new Country { Id = 117, Name = "Lesotho" },
                new Country { Id = 118, Name = "Liberia" },
                new Country { Id = 119, Name = "Libyan Arab Jamahiriya" },
                new Country { Id = 120, Name = "Liechtenstein" },
                new Country { Id = 121, Name = "Lithuania" },
                new Country { Id = 122, Name = "Luxembourg" },
                new Country { Id = 123, Name = "Macau" },
                new Country { Id = 124, Name = "Macedonia" },
                new Country { Id = 125, Name = "Madagascar" },
                new Country { Id = 126, Name = "Malawi" },
                new Country { Id = 127, Name = "Malaysia" },
                new Country { Id = 128, Name = "Maldives" },
                new Country { Id = 129, Name = "Mali" },
                new Country { Id = 130, Name = "Malta" },
                new Country { Id = 131, Name = "Marshall Islands" },
                new Country { Id = 132, Name = "Martinique" },
                new Country { Id = 133, Name = "Mauritania" },
                new Country { Id = 134, Name = "Mauritius" },
                new Country { Id = 135, Name = "Mayotte" },
                new Country { Id = 136, Name = "Mexico" },
                new Country { Id = 137, Name = "Micronesia, Federated States" },
                new Country { Id = 138, Name = "Moldova, Republic Of" },
                new Country { Id = 139, Name = "Monaco" },
                new Country { Id = 140, Name = "Mongolia" },
                new Country { Id = 141, Name = "Montserrat" },
                new Country { Id = 142, Name = "Morocco" },
                new Country { Id = 143, Name = "Mozambique" },
                new Country { Id = 144, Name = "Myanmar" },
                new Country { Id = 145, Name = "Namibia" },
                new Country { Id = 146, Name = "Nauru" },
                new Country { Id = 147, Name = "Nepal" },
                new Country { Id = 148, Name = "Netherlands" },
                new Country { Id = 149, Name = "Netherlands Ant Illes" },
                new Country { Id = 150, Name = "New Caledonia" },
                new Country { Id = 151, Name = "New Zealand" },
                new Country { Id = 152, Name = "Nicaragua" },
                new Country { Id = 153, Name = "Niger" },
                new Country { Id = 154, Name = "Nigeria" },
                new Country { Id = 155, Name = "Niue" },
                new Country { Id = 156, Name = "Norfolk Island" },
                new Country { Id = 157, Name = "Northern Mariana Islands" },
                new Country { Id = 158, Name = "Norway" },
                new Country { Id = 159, Name = "Oman" },
                new Country { Id = 160, Name = "Pakistan" },
                new Country { Id = 161, Name = "Palau" },
                new Country { Id = 162, Name = "Panama" },
                new Country { Id = 163, Name = "Papua New Guinea" },
                new Country { Id = 164, Name = "Paraguay" },
                new Country { Id = 165, Name = "Peru" },
                new Country { Id = 166, Name = "Philippines" },
                new Country { Id = 167, Name = "Pitcairn" },
                new Country { Id = 168, Name = "Poland" },
                new Country { Id = 169, Name = "Portugal" },
                new Country { Id = 170, Name = "Puerto Rico" },
                new Country { Id = 171, Name = "Qatar" },
                new Country { Id = 172, Name = "Reunion" },
                new Country { Id = 173, Name = "Romania" },
                new Country { Id = 174, Name = "Russian Federation" },
                new Country { Id = 175, Name = "Rwanda" },
                new Country { Id = 176, Name = "Saint K Itts And Nevis" },
                new Country { Id = 177, Name = "Saint Lucia" },
                new Country { Id = 178, Name = "Saint Vincent, The Grenadines" },
                new Country { Id = 179, Name = "Samoa" },
                new Country { Id = 180, Name = "San Marino" },
                new Country { Id = 181, Name = "Sao Tome And Principe" },
                new Country { Id = 182, Name = "Saudi Arabia" },
                new Country { Id = 183, Name = "Senegal" },
                new Country { Id = 184, Name = "Seychelles" },
                new Country { Id = 185, Name = "Sierra Leone" },
                new Country { Id = 186, Name = "Singapore" },
                new Country { Id = 187, Name = "Slovakia (Slovak Republic)" },
                new Country { Id = 188, Name = "Slovenia" },
                new Country { Id = 189, Name = "Solomon Islands" },
                new Country { Id = 190, Name = "Somalia" },
                new Country { Id = 191, Name = "South Africa" },
                new Country { Id = 192, Name = "South Georgia , S Sandwich Is." },
                new Country { Id = 193, Name = "Spain" },
                new Country { Id = 194, Name = "Sri Lanka" },
                new Country { Id = 195, Name = "St. Helena" },
                new Country { Id = 196, Name = "St. Pierre And Miquelon" },
                new Country { Id = 197, Name = "Sudan" },
                new Country { Id = 198, Name = "Suriname" },
                new Country { Id = 199, Name = "Svalbard, Jan Mayen Islands" },
                new Country { Id = 200, Name = "Sw Aziland" },
                new Country { Id = 201, Name = "Sweden" },
                new Country { Id = 202, Name = "Switzerland" },
                new Country { Id = 203, Name = "Syrian Arab Republic" },
                new Country { Id = 204, Name = "Taiwan" },
                new Country { Id = 205, Name = "Tajikistan" },
                new Country { Id = 206, Name = "Tanzania, United Republic Of" },
                new Country { Id = 207, Name = "Thailand" },
                new Country { Id = 208, Name = "Togo" },
                new Country { Id = 209, Name = "Tokelau" },
                new Country { Id = 210, Name = "Tonga" },
                new Country { Id = 211, Name = "Trinidad And Tobago" },
                new Country { Id = 212, Name = "Tunisia" },
                new Country { Id = 213, Name = "Turkey" },
                new Country { Id = 214, Name = "Turkmenistan" },
                new Country { Id = 215, Name = "Turks And Caicos Islands" },
                new Country { Id = 216, Name = "Tuvalu" },
                new Country { Id = 217, Name = "Uganda" },
                new Country { Id = 218, Name = "Ukraine" },
                new Country { Id = 219, Name = "United Arab Emirates" },
                new Country { Id = 220, Name = "United Kingdom" },
                new Country { Id = 221, Name = "United States" },
                new Country { Id = 222, Name = "United States Minor Is." },
                new Country { Id = 223, Name = "Uruguay" },
                new Country { Id = 224, Name = "Uzbekistan" },
                new Country { Id = 225, Name = "Vanuatu" },
                new Country { Id = 226, Name = "Venezuela" },
                new Country { Id = 227, Name = "Viet Nam" },
                new Country { Id = 228, Name = "Virgin Islands (British)" },
                new Country { Id = 229, Name = "Virgin Islands (U.S.)" },
                new Country { Id = 230, Name = "Wallis And Futuna Islands" },
                new Country { Id = 231, Name = "Western Sahara" },
                new Country { Id = 232, Name = "Yemen" },
                new Country { Id = 233, Name = "Yugoslavia" },
                new Country { Id = 234, Name = "Zaire" },
                new Country { Id = 235, Name = "Zambia" },
                new Country { Id = 236, Name = "Zimbabwe" }
            );
            #endregion

            // Seed data for Product
            #region
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Code = "001",
                    Name = "ვაშლი",
                    Price = 2.99,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(30),
                    CountryId = 80,
                    GroupId = 3
                },
                new Product
                {
                    Id = 2,
                    Code = "002",
                    Name = "მსხალი",
                    Price = 3.99,
                    StartDate = DateTime.Now.AddDays(-15),
                    EndDate = DateTime.Now.AddDays(2),
                    CountryId = 213,
                    GroupId = 3
                },
                new Product
                {
                    Id = 3,
                    Code = "003",
                    Name = "საზამთრო",
                    Price = 5.50,
                    StartDate = DateTime.Now.AddDays(-3),
                    EndDate = DateTime.Now.AddDays(6),
                    CountryId = 16,
                    GroupId = 3
                },
                new Product
                {
                    Id = 4,
                    Code = "004",
                    Name = "კოკა-კოლა",
                    Price = 4.20,
                    StartDate = DateTime.Now.AddDays(-6),
                    EndDate = DateTime.Now.AddDays(7),
                    CountryId = 80,
                    GroupId = 7
                }
                ,
                new Product
                {
                    Id = 5,
                    Code = "005",
                    Name = "პეპსი",
                    Price = 4.00,
                    StartDate = DateTime.Now.AddDays(-1),
                    EndDate = DateTime.Now.AddDays(3),
                    CountryId = 80,
                    GroupId = 7
                }
            );
            #endregion

            // Seed data for Group
            #region
            modelBuilder.Entity<Group>().HasData(
                new Group { Id = 1, Name = "პროდუქტები", ParentGroupId = null },
                // Subgroups of პროდუქტები
                new Group { Id = 3, Name = "აგრარული", ParentGroupId = 1 },
                new Group { Id = 4, Name = "კვება", ParentGroupId = 1 },
                // Subgroups of აგრარული
                new Group { Id = 5, Name = "ხილი", ParentGroupId = 3 },
                new Group { Id = 6, Name = "ბოსტნეული", ParentGroupId = 3 },
                // Subgroups of კვება
                new Group { Id = 7, Name = "სასმელები", ParentGroupId = 4 },
                new Group { Id = 8, Name = "კერძები", ParentGroupId = 4 }
            );
            #endregion
        }
    }
}
