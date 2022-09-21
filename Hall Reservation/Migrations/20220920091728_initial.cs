using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hall_Reservation.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "JOR15_USER88");

            migrationBuilder.CreateSequence(
                name: "SEQUENCE_DEP_ID",
                schema: "JOR15_USER88");

            migrationBuilder.CreateSequence(
                name: "SEQUENCEDEPARTMENT",
                schema: "JOR15_USER88");

            migrationBuilder.CreateTable(
                name: "ADDRESS",
                schema: "JOR15_USER88",
                columns: table => new
                {
                    ADDRESS_ID = table.Column<decimal>(type: "NUMBER", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    CITY = table.Column<string>(type: "VARCHAR2(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADDRESS", x => x.ADDRESS_ID);
                });

            migrationBuilder.CreateTable(
                name: "CATEGORIES",
                schema: "JOR15_USER88",
                columns: table => new
                {
                    CAT_ID = table.Column<decimal>(type: "NUMBER", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    CAT_NAME = table.Column<string>(type: "VARCHAR2(50)", unicode: false, maxLength: 50, nullable: true),
                    CAT_IMAGE_PATH = table.Column<string>(type: "VARCHAR2(300)", unicode: false, maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("SYS_C00273143", x => x.CAT_ID);
                });

            migrationBuilder.CreateTable(
                name: "CHECKLIST",
                schema: "JOR15_USER88",
                columns: table => new
                {
                    CHECKED_ID = table.Column<decimal>(type: "NUMBER", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    STATUS = table.Column<string>(type: "VARCHAR2(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("SYS_C00273164", x => x.CHECKED_ID);
                });

            migrationBuilder.CreateTable(
                name: "HOME",
                schema: "JOR15_USER88",
                columns: table => new
                {
                    ID = table.Column<decimal>(type: "NUMBER", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    IMAGE_1 = table.Column<string>(type: "VARCHAR2(250)", unicode: false, maxLength: 250, nullable: true),
                    TITLE_1 = table.Column<string>(type: "VARCHAR2(250)", unicode: false, maxLength: 250, nullable: true),
                    IMAGE_2 = table.Column<string>(type: "VARCHAR2(250)", unicode: false, maxLength: 250, nullable: true),
                    TITLE_2 = table.Column<string>(type: "VARCHAR2(250)", unicode: false, maxLength: 250, nullable: true),
                    IMAGE_3 = table.Column<string>(type: "VARCHAR2(250)", unicode: false, maxLength: 250, nullable: true),
                    TITLE_3 = table.Column<string>(type: "VARCHAR2(250)", unicode: false, maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HOME", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ROLESS",
                schema: "JOR15_USER88",
                columns: table => new
                {
                    ROLE_ID = table.Column<decimal>(type: "NUMBER", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ROLE_NAME = table.Column<string>(type: "VARCHAR2(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("SYS_C00273134", x => x.ROLE_ID);
                });

            migrationBuilder.CreateTable(
                name: "USERS",
                schema: "JOR15_USER88",
                columns: table => new
                {
                    USER_ID = table.Column<decimal>(type: "NUMBER", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    FNAME = table.Column<string>(type: "VARCHAR2(50)", unicode: false, maxLength: 50, nullable: false),
                    LNAME = table.Column<string>(type: "VARCHAR2(50)", unicode: false, maxLength: 50, nullable: false),
                    USER_NAME = table.Column<string>(type: "VARCHAR2(50)", unicode: false, maxLength: 50, nullable: false),
                    PASSWORD = table.Column<string>(type: "VARCHAR2(50)", unicode: false, maxLength: 50, nullable: false),
                    PHONENUMBER = table.Column<long>(type: "NUMBER(14)", precision: 14, nullable: true),
                    EMAIL = table.Column<string>(type: "VARCHAR2(50)", unicode: false, maxLength: 50, nullable: true),
                    USER_IMAGE = table.Column<string>(type: "VARCHAR2(300)", unicode: false, maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERS", x => x.USER_ID);
                });

            migrationBuilder.CreateTable(
                name: "HALL",
                schema: "JOR15_USER88",
                columns: table => new
                {
                    HALL_ID = table.Column<decimal>(type: "NUMBER", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    CATEGORY_ID = table.Column<decimal>(type: "NUMBER", nullable: true),
                    HALL_NAME = table.Column<string>(type: "VARCHAR2(50)", unicode: false, maxLength: 50, nullable: false),
                    HALL_CAPACITY = table.Column<decimal>(type: "NUMBER", nullable: false),
                    IMAGE_PATH = table.Column<string>(type: "VARCHAR2(300)", unicode: false, maxLength: 300, nullable: true),
                    HALL_DESCRIPTION = table.Column<string>(type: "VARCHAR2(500)", unicode: false, maxLength: 500, nullable: true),
                    BOOKING_PRICE = table.Column<decimal>(type: "NUMBER", nullable: false),
                    ADDRESS_ID = table.Column<decimal>(type: "NUMBER", nullable: true),
                    STREET = table.Column<string>(type: "VARCHAR2(50)", unicode: false, maxLength: 50, nullable: true),
                    BUILDING_NUMBER = table.Column<decimal>(type: "NUMBER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HALL", x => x.HALL_ID);
                    table.ForeignKey(
                        name: "SYS_C00273151",
                        column: x => x.CATEGORY_ID,
                        principalSchema: "JOR15_USER88",
                        principalTable: "CATEGORIES",
                        principalColumn: "CAT_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "SYS_C00273152",
                        column: x => x.ADDRESS_ID,
                        principalSchema: "JOR15_USER88",
                        principalTable: "ADDRESS",
                        principalColumn: "ADDRESS_ID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "ABOUT_US",
                schema: "JOR15_USER88",
                columns: table => new
                {
                    BOOKING_ID = table.Column<decimal>(type: "NUMBER", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NAME = table.Column<string>(type: "VARCHAR2(100)", unicode: false, maxLength: 100, nullable: true),
                    EMAIL = table.Column<string>(type: "VARCHAR2(100)", unicode: false, maxLength: 100, nullable: true),
                    PHONE_NUMBER = table.Column<long>(type: "NUMBER(17)", precision: 17, nullable: true),
                    ADDRESS = table.Column<string>(type: "VARCHAR2(100)", unicode: false, maxLength: 100, nullable: true),
                    HOME_ID = table.Column<decimal>(type: "NUMBER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ABOUT_US_PK", x => x.BOOKING_ID);
                    table.ForeignKey(
                        name: "SYS_C00273183",
                        column: x => x.HOME_ID,
                        principalSchema: "JOR15_USER88",
                        principalTable: "HOME",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "CONTACT_US",
                schema: "JOR15_USER88",
                columns: table => new
                {
                    ID = table.Column<decimal>(type: "NUMBER", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NAME = table.Column<string>(type: "VARCHAR2(100)", unicode: false, maxLength: 100, nullable: true),
                    EMAIL = table.Column<string>(type: "VARCHAR2(100)", unicode: false, maxLength: 100, nullable: true),
                    PHONE_NUMBER = table.Column<long>(type: "NUMBER(17)", precision: 17, nullable: true),
                    MESSAGE = table.Column<string>(type: "VARCHAR2(300)", unicode: false, maxLength: 300, nullable: true),
                    HOME_ID = table.Column<decimal>(type: "NUMBER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONTACT_US", x => x.ID);
                    table.ForeignKey(
                        name: "SYS_C00273186",
                        column: x => x.HOME_ID,
                        principalSchema: "JOR15_USER88",
                        principalTable: "HOME",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "LOGIN",
                schema: "JOR15_USER88",
                columns: table => new
                {
                    LOGIN_ID = table.Column<decimal>(type: "NUMBER", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    USER_NAME = table.Column<string>(type: "VARCHAR2(200)", unicode: false, maxLength: 200, nullable: false),
                    PASSWORD = table.Column<string>(type: "VARCHAR2(50)", unicode: false, maxLength: 50, nullable: false),
                    USER_ID = table.Column<decimal>(type: "NUMBER", nullable: true),
                    ROLES_ID = table.Column<decimal>(type: "NUMBER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOGIN", x => x.LOGIN_ID);
                    table.ForeignKey(
                        name: "SYS_C00273140",
                        column: x => x.USER_ID,
                        principalSchema: "JOR15_USER88",
                        principalTable: "USERS",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "SYS_C00273141",
                        column: x => x.ROLES_ID,
                        principalSchema: "JOR15_USER88",
                        principalTable: "ROLESS",
                        principalColumn: "ROLE_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TESTIMONIAL",
                schema: "JOR15_USER88",
                columns: table => new
                {
                    ID = table.Column<decimal>(type: "NUMBER", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    RATING = table.Column<int>(type: "NUMBER(10)", precision: 10, nullable: true),
                    OPINION = table.Column<string>(type: "VARCHAR2(100)", unicode: false, maxLength: 100, nullable: true),
                    USER_ID = table.Column<decimal>(type: "NUMBER", nullable: true),
                    HOME_ID = table.Column<decimal>(type: "NUMBER", nullable: true),
                    STATUS = table.Column<decimal>(type: "NUMBER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TESTIMONIAL", x => x.ID);
                    table.ForeignKey(
                        name: "SYS_C00273189",
                        column: x => x.USER_ID,
                        principalSchema: "JOR15_USER88",
                        principalTable: "USERS",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "SYS_C00273190",
                        column: x => x.HOME_ID,
                        principalSchema: "JOR15_USER88",
                        principalTable: "HOME",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "SYS_C00273191",
                        column: x => x.STATUS,
                        principalSchema: "JOR15_USER88",
                        principalTable: "CHECKLIST",
                        principalColumn: "CHECKED_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VISA",
                schema: "JOR15_USER88",
                columns: table => new
                {
                    VISA_ID = table.Column<decimal>(type: "NUMBER", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    VISA_NAME = table.Column<string>(type: "VARCHAR2(50)", unicode: false, maxLength: 50, nullable: true),
                    VISA_NUMBER = table.Column<long>(type: "NUMBER(16)", precision: 16, nullable: false),
                    VISA_AMOUNT = table.Column<decimal>(type: "NUMBER", nullable: false),
                    END_DATE = table.Column<DateTime>(type: "DATE", nullable: true),
                    CVC_CVV = table.Column<byte>(type: "NUMBER(3)", precision: 3, nullable: true),
                    USER_ID = table.Column<decimal>(type: "NUMBER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VISA", x => x.VISA_ID);
                    table.ForeignKey(
                        name: "SYS_C00273131",
                        column: x => x.USER_ID,
                        principalSchema: "JOR15_USER88",
                        principalTable: "USERS",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BOOKING",
                schema: "JOR15_USER88",
                columns: table => new
                {
                    BOOKING_ID = table.Column<decimal>(type: "NUMBER", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    START_DATE = table.Column<DateTime>(type: "DATE", nullable: false),
                    END_DATE = table.Column<DateTime>(type: "DATE", nullable: false),
                    HALL_ID = table.Column<decimal>(type: "NUMBER", nullable: true),
                    USER_ID = table.Column<decimal>(type: "NUMBER", nullable: true),
                    CREATION_DATE = table.Column<DateTime>(type: "DATE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BOOKING", x => x.BOOKING_ID);
                    table.ForeignKey(
                        name: "SYS_C00273161",
                        column: x => x.HALL_ID,
                        principalSchema: "JOR15_USER88",
                        principalTable: "HALL",
                        principalColumn: "HALL_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "SYS_C00273162",
                        column: x => x.USER_ID,
                        principalSchema: "JOR15_USER88",
                        principalTable: "USERS",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "REVIEWS",
                schema: "JOR15_USER88",
                columns: table => new
                {
                    REVIEWS_ID = table.Column<decimal>(type: "NUMBER", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    RATING = table.Column<int>(type: "NUMBER(10)", precision: 10, nullable: true),
                    OPINION = table.Column<string>(type: "VARCHAR2(500)", unicode: false, maxLength: 500, nullable: true),
                    USER_ID = table.Column<decimal>(type: "NUMBER", nullable: true),
                    HALL_ID = table.Column<decimal>(type: "NUMBER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("SYS_C00273154", x => x.REVIEWS_ID);
                    table.ForeignKey(
                        name: "SYS_C00273155",
                        column: x => x.USER_ID,
                        principalSchema: "JOR15_USER88",
                        principalTable: "USERS",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "SYS_C00273156",
                        column: x => x.HALL_ID,
                        principalSchema: "JOR15_USER88",
                        principalTable: "HALL",
                        principalColumn: "HALL_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CHECKED",
                schema: "JOR15_USER88",
                columns: table => new
                {
                    CHECK_ID = table.Column<decimal>(type: "NUMBER", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    USER_ID = table.Column<decimal>(type: "NUMBER", nullable: true),
                    HALL_ID = table.Column<decimal>(type: "NUMBER", nullable: true),
                    BOOKING_ID = table.Column<decimal>(type: "NUMBER", nullable: true),
                    CHECKED_DATE = table.Column<DateTime>(type: "DATE", nullable: false),
                    STATUS = table.Column<decimal>(type: "NUMBER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("SYS_C00273167", x => x.CHECK_ID);
                    table.ForeignKey(
                        name: "SYS_C00273168",
                        column: x => x.USER_ID,
                        principalSchema: "JOR15_USER88",
                        principalTable: "USERS",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "SYS_C00273169",
                        column: x => x.HALL_ID,
                        principalSchema: "JOR15_USER88",
                        principalTable: "HALL",
                        principalColumn: "HALL_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "SYS_C00273170",
                        column: x => x.BOOKING_ID,
                        principalSchema: "JOR15_USER88",
                        principalTable: "BOOKING",
                        principalColumn: "BOOKING_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "SYS_C00273171",
                        column: x => x.STATUS,
                        principalSchema: "JOR15_USER88",
                        principalTable: "CHECKLIST",
                        principalColumn: "CHECKED_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PAYMENT",
                schema: "JOR15_USER88",
                columns: table => new
                {
                    PAY_ID = table.Column<decimal>(type: "NUMBER", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    STATUS = table.Column<decimal>(type: "NUMBER", nullable: true),
                    PAY_AMOUNT = table.Column<decimal>(type: "NUMBER", nullable: true),
                    HALL_NAME = table.Column<decimal>(type: "NUMBER", nullable: true),
                    PAY_DATE = table.Column<DateTime>(type: "DATE", nullable: false),
                    PAY_DESC = table.Column<string>(type: "VARCHAR2(200)", unicode: false, maxLength: 200, nullable: true),
                    PAY_USER_ID = table.Column<decimal>(type: "NUMBER", nullable: true),
                    VISA_ID = table.Column<decimal>(type: "NUMBER", nullable: true),
                    BOOKING_ID = table.Column<decimal>(type: "NUMBER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("SYS_C00273174", x => x.PAY_ID);
                    table.ForeignKey(
                        name: "SYS_C00273175",
                        column: x => x.STATUS,
                        principalSchema: "JOR15_USER88",
                        principalTable: "CHECKED",
                        principalColumn: "CHECK_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "SYS_C00273176",
                        column: x => x.PAY_AMOUNT,
                        principalSchema: "JOR15_USER88",
                        principalTable: "HALL",
                        principalColumn: "HALL_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "SYS_C00273177",
                        column: x => x.HALL_NAME,
                        principalSchema: "JOR15_USER88",
                        principalTable: "HALL",
                        principalColumn: "HALL_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "SYS_C00273178",
                        column: x => x.PAY_USER_ID,
                        principalSchema: "JOR15_USER88",
                        principalTable: "USERS",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "SYS_C00273179",
                        column: x => x.VISA_ID,
                        principalSchema: "JOR15_USER88",
                        principalTable: "VISA",
                        principalColumn: "VISA_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "SYS_C00273180",
                        column: x => x.BOOKING_ID,
                        principalSchema: "JOR15_USER88",
                        principalTable: "BOOKING",
                        principalColumn: "BOOKING_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ABOUT_US_HOME_ID",
                schema: "JOR15_USER88",
                table: "ABOUT_US",
                column: "HOME_ID");

            migrationBuilder.CreateIndex(
                name: "IX_BOOKING_HALL_ID",
                schema: "JOR15_USER88",
                table: "BOOKING",
                column: "HALL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_BOOKING_USER_ID",
                schema: "JOR15_USER88",
                table: "BOOKING",
                column: "USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CHECKED_BOOKING_ID",
                schema: "JOR15_USER88",
                table: "CHECKED",
                column: "BOOKING_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CHECKED_HALL_ID",
                schema: "JOR15_USER88",
                table: "CHECKED",
                column: "HALL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CHECKED_STATUS",
                schema: "JOR15_USER88",
                table: "CHECKED",
                column: "STATUS");

            migrationBuilder.CreateIndex(
                name: "IX_CHECKED_USER_ID",
                schema: "JOR15_USER88",
                table: "CHECKED",
                column: "USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CONTACT_US_HOME_ID",
                schema: "JOR15_USER88",
                table: "CONTACT_US",
                column: "HOME_ID");

            migrationBuilder.CreateIndex(
                name: "IX_HALL_ADDRESS_ID",
                schema: "JOR15_USER88",
                table: "HALL",
                column: "ADDRESS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_HALL_CATEGORY_ID",
                schema: "JOR15_USER88",
                table: "HALL",
                column: "CATEGORY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_LOGIN_ROLES_ID",
                schema: "JOR15_USER88",
                table: "LOGIN",
                column: "ROLES_ID");

            migrationBuilder.CreateIndex(
                name: "IX_LOGIN_USER_ID",
                schema: "JOR15_USER88",
                table: "LOGIN",
                column: "USER_ID");

            migrationBuilder.CreateIndex(
                name: "SYS_C00273139",
                schema: "JOR15_USER88",
                table: "LOGIN",
                column: "USER_NAME",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PAYMENT_BOOKING_ID",
                schema: "JOR15_USER88",
                table: "PAYMENT",
                column: "BOOKING_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PAYMENT_HALL_NAME",
                schema: "JOR15_USER88",
                table: "PAYMENT",
                column: "HALL_NAME");

            migrationBuilder.CreateIndex(
                name: "IX_PAYMENT_PAY_AMOUNT",
                schema: "JOR15_USER88",
                table: "PAYMENT",
                column: "PAY_AMOUNT");

            migrationBuilder.CreateIndex(
                name: "IX_PAYMENT_PAY_USER_ID",
                schema: "JOR15_USER88",
                table: "PAYMENT",
                column: "PAY_USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PAYMENT_STATUS",
                schema: "JOR15_USER88",
                table: "PAYMENT",
                column: "STATUS");

            migrationBuilder.CreateIndex(
                name: "IX_PAYMENT_VISA_ID",
                schema: "JOR15_USER88",
                table: "PAYMENT",
                column: "VISA_ID");

            migrationBuilder.CreateIndex(
                name: "IX_REVIEWS_HALL_ID",
                schema: "JOR15_USER88",
                table: "REVIEWS",
                column: "HALL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_REVIEWS_USER_ID",
                schema: "JOR15_USER88",
                table: "REVIEWS",
                column: "USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TESTIMONIAL_HOME_ID",
                schema: "JOR15_USER88",
                table: "TESTIMONIAL",
                column: "HOME_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TESTIMONIAL_STATUS",
                schema: "JOR15_USER88",
                table: "TESTIMONIAL",
                column: "STATUS");

            migrationBuilder.CreateIndex(
                name: "IX_TESTIMONIAL_USER_ID",
                schema: "JOR15_USER88",
                table: "TESTIMONIAL",
                column: "USER_ID");

            migrationBuilder.CreateIndex(
                name: "SYS_C00273126",
                schema: "JOR15_USER88",
                table: "USERS",
                column: "USER_NAME",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VISA_USER_ID",
                schema: "JOR15_USER88",
                table: "VISA",
                column: "USER_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ABOUT_US",
                schema: "JOR15_USER88");

            migrationBuilder.DropTable(
                name: "CONTACT_US",
                schema: "JOR15_USER88");

            migrationBuilder.DropTable(
                name: "LOGIN",
                schema: "JOR15_USER88");

            migrationBuilder.DropTable(
                name: "PAYMENT",
                schema: "JOR15_USER88");

            migrationBuilder.DropTable(
                name: "REVIEWS",
                schema: "JOR15_USER88");

            migrationBuilder.DropTable(
                name: "TESTIMONIAL",
                schema: "JOR15_USER88");

            migrationBuilder.DropTable(
                name: "ROLESS",
                schema: "JOR15_USER88");

            migrationBuilder.DropTable(
                name: "CHECKED",
                schema: "JOR15_USER88");

            migrationBuilder.DropTable(
                name: "VISA",
                schema: "JOR15_USER88");

            migrationBuilder.DropTable(
                name: "HOME",
                schema: "JOR15_USER88");

            migrationBuilder.DropTable(
                name: "BOOKING",
                schema: "JOR15_USER88");

            migrationBuilder.DropTable(
                name: "CHECKLIST",
                schema: "JOR15_USER88");

            migrationBuilder.DropTable(
                name: "HALL",
                schema: "JOR15_USER88");

            migrationBuilder.DropTable(
                name: "USERS",
                schema: "JOR15_USER88");

            migrationBuilder.DropTable(
                name: "CATEGORIES",
                schema: "JOR15_USER88");

            migrationBuilder.DropTable(
                name: "ADDRESS",
                schema: "JOR15_USER88");

            migrationBuilder.DropSequence(
                name: "SEQUENCE_DEP_ID",
                schema: "JOR15_USER88");

            migrationBuilder.DropSequence(
                name: "SEQUENCEDEPARTMENT",
                schema: "JOR15_USER88");
        }
    }
}
