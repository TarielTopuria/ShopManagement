using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductManagementService.Migrations
{
    /// <inheritdoc />
    public partial class SeedGroupsWithSubgroups : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentGroupId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Groups_Groups_ParentGroupId",
                        column: x => x.ParentGroupId,
                        principalTable: "Groups",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "United States" },
                    { 2, "Afghanistan" },
                    { 3, "Albania" },
                    { 4, "Algeria" },
                    { 5, "American Samoa" },
                    { 6, "Andorra" },
                    { 7, "Angola" },
                    { 8, "Anguilla" },
                    { 9, "Antarctica" },
                    { 10, "Antigua And Barbuda" },
                    { 11, "Argentina" },
                    { 12, "Armenia" },
                    { 13, "Aruba" },
                    { 14, "Australia" },
                    { 15, "Austria" },
                    { 16, "Azerbaijan" },
                    { 17, "Bahamas" },
                    { 18, "Bahrain" },
                    { 19, "Bangladesh" },
                    { 20, "Barbados" },
                    { 21, "Belarus" },
                    { 22, "Belgium" },
                    { 23, "Belize" },
                    { 24, "Benin" },
                    { 25, "Bermuda" },
                    { 26, "Bhutan" },
                    { 27, "Bolivia" },
                    { 28, "Bosnia And Herzegowina" },
                    { 29, "Botswana" },
                    { 30, "Bouvet Island" },
                    { 31, "Brazil" },
                    { 32, "British Indian Ocean Territory" },
                    { 33, "Brunei Darussalam" },
                    { 34, "Bulgaria" },
                    { 35, "Burkina Faso" },
                    { 36, "Burundi" },
                    { 37, "Cambodia" },
                    { 38, "Cameroon" },
                    { 39, "Canada" },
                    { 40, "Cape Verde" },
                    { 41, "Cayman Islands" },
                    { 42, "Central African Republic" },
                    { 43, "Chad" },
                    { 44, "Chile" },
                    { 45, "China" },
                    { 46, "Christmas Island" },
                    { 47, "Cocos (Keeling) Islands" },
                    { 48, "Colombia" },
                    { 49, "Comoros" },
                    { 50, "Congo" },
                    { 51, "Cook Islands" },
                    { 52, "Costa Rica" },
                    { 53, "Cote D'Ivoire" },
                    { 54, "Croatia (Local Name: Hrvatska)" },
                    { 55, "Cuba" },
                    { 56, "Cyprus" },
                    { 57, "Czech Republic" },
                    { 58, "Denmark" },
                    { 59, "Djibouti" },
                    { 60, "Dominica" },
                    { 61, "Dominican Republic" },
                    { 62, "East Timor" },
                    { 63, "Ecuador" },
                    { 64, "Egypt" },
                    { 65, "El Salvador" },
                    { 66, "Equatorial Guinea" },
                    { 67, "Eritrea" },
                    { 68, "Estonia" },
                    { 69, "Ethiopia" },
                    { 70, "Falkland Islands (Malvinas)" },
                    { 71, "Faroe Islands" },
                    { 72, "Fiji" },
                    { 73, "Finland" },
                    { 74, "France" },
                    { 75, "French Guiana" },
                    { 76, "French Polynesia" },
                    { 77, "French Southern Territories" },
                    { 78, "Gabon" },
                    { 79, "Gambia" },
                    { 80, "Georgia" },
                    { 81, "Germany" },
                    { 82, "Ghana" },
                    { 83, "Gibraltar" },
                    { 84, "Greece" },
                    { 85, "Greenland" },
                    { 86, "Grenada" },
                    { 87, "Guadeloupe" },
                    { 88, "Guam" },
                    { 89, "Guatemala" },
                    { 90, "Guinea" },
                    { 91, "Guinea-Bissau" },
                    { 92, "Guyana" },
                    { 93, "Haiti" },
                    { 94, "Honduras" },
                    { 95, "Hong Kong" },
                    { 96, "Hungary" },
                    { 97, "Icel And" },
                    { 98, "India" },
                    { 99, "Indonesia" },
                    { 100, "Iran (Islamic Republic Of)" },
                    { 101, "Iraq" },
                    { 102, "Ireland" },
                    { 103, "Israel" },
                    { 104, "Italy" },
                    { 105, "Jamaica" },
                    { 106, "Japan" },
                    { 107, "Jordan" },
                    { 108, "Kazakhstan" },
                    { 109, "Kenya" },
                    { 110, "Kiribati" },
                    { 111, "Korea" },
                    { 112, "Kuwait" },
                    { 113, "Kyrgyzstan" },
                    { 114, "Lao People'S Dem Republic" },
                    { 115, "Latvia" },
                    { 116, "Lebanon" },
                    { 117, "Lesotho" },
                    { 118, "Liberia" },
                    { 119, "Libyan Arab Jamahiriya" },
                    { 120, "Liechtenstein" },
                    { 121, "Lithuania" },
                    { 122, "Luxembourg" },
                    { 123, "Macau" },
                    { 124, "Macedonia" },
                    { 125, "Madagascar" },
                    { 126, "Malawi" },
                    { 127, "Malaysia" },
                    { 128, "Maldives" },
                    { 129, "Mali" },
                    { 130, "Malta" },
                    { 131, "Marshall Islands" },
                    { 132, "Martinique" },
                    { 133, "Mauritania" },
                    { 134, "Mauritius" },
                    { 135, "Mayotte" },
                    { 136, "Mexico" },
                    { 137, "Micronesia, Federated States" },
                    { 138, "Moldova, Republic Of" },
                    { 139, "Monaco" },
                    { 140, "Mongolia" },
                    { 141, "Montserrat" },
                    { 142, "Morocco" },
                    { 143, "Mozambique" },
                    { 144, "Myanmar" },
                    { 145, "Namibia" },
                    { 146, "Nauru" },
                    { 147, "Nepal" },
                    { 148, "Netherlands" },
                    { 149, "Netherlands Ant Illes" },
                    { 150, "New Caledonia" },
                    { 151, "New Zealand" },
                    { 152, "Nicaragua" },
                    { 153, "Niger" },
                    { 154, "Nigeria" },
                    { 155, "Niue" },
                    { 156, "Norfolk Island" },
                    { 157, "Northern Mariana Islands" },
                    { 158, "Norway" },
                    { 159, "Oman" },
                    { 160, "Pakistan" },
                    { 161, "Palau" },
                    { 162, "Panama" },
                    { 163, "Papua New Guinea" },
                    { 164, "Paraguay" },
                    { 165, "Peru" },
                    { 166, "Philippines" },
                    { 167, "Pitcairn" },
                    { 168, "Poland" },
                    { 169, "Portugal" },
                    { 170, "Puerto Rico" },
                    { 171, "Qatar" },
                    { 172, "Reunion" },
                    { 173, "Romania" },
                    { 174, "Russian Federation" },
                    { 175, "Rwanda" },
                    { 176, "Saint K Itts And Nevis" },
                    { 177, "Saint Lucia" },
                    { 178, "Saint Vincent, The Grenadines" },
                    { 179, "Samoa" },
                    { 180, "San Marino" },
                    { 181, "Sao Tome And Principe" },
                    { 182, "Saudi Arabia" },
                    { 183, "Senegal" },
                    { 184, "Seychelles" },
                    { 185, "Sierra Leone" },
                    { 186, "Singapore" },
                    { 187, "Slovakia (Slovak Republic)" },
                    { 188, "Slovenia" },
                    { 189, "Solomon Islands" },
                    { 190, "Somalia" },
                    { 191, "South Africa" },
                    { 192, "South Georgia , S Sandwich Is." },
                    { 193, "Spain" },
                    { 194, "Sri Lanka" },
                    { 195, "St. Helena" },
                    { 196, "St. Pierre And Miquelon" },
                    { 197, "Sudan" },
                    { 198, "Suriname" },
                    { 199, "Svalbard, Jan Mayen Islands" },
                    { 200, "Sw Aziland" },
                    { 201, "Sweden" },
                    { 202, "Switzerland" },
                    { 203, "Syrian Arab Republic" },
                    { 204, "Taiwan" },
                    { 205, "Tajikistan" },
                    { 206, "Tanzania, United Republic Of" },
                    { 207, "Thailand" },
                    { 208, "Togo" },
                    { 209, "Tokelau" },
                    { 210, "Tonga" },
                    { 211, "Trinidad And Tobago" },
                    { 212, "Tunisia" },
                    { 213, "Turkey" },
                    { 214, "Turkmenistan" },
                    { 215, "Turks And Caicos Islands" },
                    { 216, "Tuvalu" },
                    { 217, "Uganda" },
                    { 218, "Ukraine" },
                    { 219, "United Arab Emirates" },
                    { 220, "United Kingdom" },
                    { 221, "United States" },
                    { 222, "United States Minor Is." },
                    { 223, "Uruguay" },
                    { 224, "Uzbekistan" },
                    { 225, "Vanuatu" },
                    { 226, "Venezuela" },
                    { 227, "Viet Nam" },
                    { 228, "Virgin Islands (British)" },
                    { 229, "Virgin Islands (U.S.)" },
                    { 230, "Wallis And Futuna Islands" },
                    { 231, "Western Sahara" },
                    { 232, "Yemen" },
                    { 233, "Yugoslavia" },
                    { 234, "Zaire" },
                    { 235, "Zambia" },
                    { 236, "Zimbabwe" }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Name", "ParentGroupId" },
                values: new object[,]
                {
                    { 1, "პროდუქტები", null },
                    { 3, "აგრარული", 1 },
                    { 4, "კვება", 1 },
                    { 5, "ხილი", 3 },
                    { 6, "ბოსტნეული", 3 },
                    { 7, "სასმელები", 4 },
                    { 8, "კერძები", 4 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Code", "CountryId", "EndDate", "GroupId", "Name", "Price", "StartDate" },
                values: new object[,]
                {
                    { 1, "001", 80, new DateTime(2024, 3, 27, 23, 4, 36, 572, DateTimeKind.Local).AddTicks(4436), 3, "ვაშლი", 2.9900000000000002, new DateTime(2024, 2, 26, 23, 4, 36, 572, DateTimeKind.Local).AddTicks(4424) },
                    { 2, "002", 213, new DateTime(2024, 2, 28, 23, 4, 36, 572, DateTimeKind.Local).AddTicks(4445), 3, "მსხალი", 3.9900000000000002, new DateTime(2024, 2, 11, 23, 4, 36, 572, DateTimeKind.Local).AddTicks(4445) },
                    { 3, "003", 16, new DateTime(2024, 3, 3, 23, 4, 36, 572, DateTimeKind.Local).AddTicks(4448), 3, "საზამთრო", 5.5, new DateTime(2024, 2, 23, 23, 4, 36, 572, DateTimeKind.Local).AddTicks(4447) },
                    { 4, "004", 80, new DateTime(2024, 3, 4, 23, 4, 36, 572, DateTimeKind.Local).AddTicks(4450), 7, "კოკა-კოლა", 4.2000000000000002, new DateTime(2024, 2, 20, 23, 4, 36, 572, DateTimeKind.Local).AddTicks(4449) },
                    { 5, "005", 80, new DateTime(2024, 2, 29, 23, 4, 36, 572, DateTimeKind.Local).AddTicks(4452), 7, "პეპსი", 4.0, new DateTime(2024, 2, 25, 23, 4, 36, 572, DateTimeKind.Local).AddTicks(4451) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Groups_ParentGroupId",
                table: "Groups",
                column: "ParentGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CountryId",
                table: "Products",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_GroupId",
                table: "Products",
                column: "GroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Groups");
        }
    }
}
