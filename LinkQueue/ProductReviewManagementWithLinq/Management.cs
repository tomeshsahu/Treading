using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReviewManagementWithLinq
{

    class Management
    {
        // public readonly DataTable dataTable = new DataTable();
        public void TopRecords(List<ProductReview> listProductReview)
        {
            var recordedData = (from productReviews in listProductReview
                                orderby productReviews.Rating descending
                                select productReviews).Take(3);


            foreach (var list in recordedData)
            {
                Console.WriteLine("ProductID:- " + list.ProducID + " " + "UserID:- " + list.UserID
                    + " " + "Rating:- " + list.Rating + " " + "Review:- " + list.Review + " " + "isLike:- " + list.isLike);
            }

        }

        public void SelectedRecords(List<ProductReview> listProductReview)
        {
            var recordedData = from productReviews in listProductReview
                               where (productReviews.ProducID == 1 || productReviews.ProducID == 4 || productReviews.ProducID == 9)
                               && productReviews.Rating > 3
                               select productReviews;
            //Console.WriteLine(recordedData);
            foreach (var list in recordedData)
            {
                Console.WriteLine("ProductID:- " + list.ProducID + " " + "UserID:- " + list.UserID
                    + " " + "Rating:- " + list.Rating + " " + "Review:- " + list.Review + " " + "isLike:- " + list.isLike);
            }

        }

        public void RetrieveCountOfRecords(List<ProductReview> listProductReview)
        {
            var recordedData = listProductReview.GroupBy(y => y.ProducID).Select(x => new { ProductID = x.Key, Count = x.Count() });


            foreach (var list in recordedData)
            {
                Console.WriteLine(list.ProductID + "--------" + list.Count);

            }
        }

        public void RetriveProductIdAndReview(List<ProductReview> listProductReview)
        {
            var recordedData = (from productReviews in listProductReview select productReviews);
            foreach (var list in recordedData)
            {
                Console.WriteLine("ProductID:- " + list.ProducID + "Review:- " + list.Review + " ");
            }
        }

        public void SkipRecord(List<ProductReview> listProductReviews)
        {
            var recordedData = listProductReviews.OrderByDescending(x => x.ProducID).Skip(5).ToList();
            foreach (var list in recordedData)
            {
                Console.WriteLine("ProductID:- " + list.ProducID + " " + "UserID:- " + list.UserID
                    + " " + "Rating:- " + list.Rating + " " + "Review:- " + list.Review + " " + "isLike:- " + list.isLike);
            }
        }

        public void DataTables()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ProductId");
            dt.Columns.Add("UserId");
            dt.Columns.Add("Review");
            dt.Columns.Add("Rating");
            dt.Columns.Add("IsLike");

            //Created Row
            dt.Rows.Add("1", "2", "good", "4", "True");
            dt.Rows.Add("2", "2", "bad", "2", "False");
            dt.Rows.Add("3", "1", "Very Good", "5", "True");
            dt.Rows.Add("4", "3", "bad", "2", "False");
            dt.Rows.Add("5", "2", "bad", "2", "False");
            dt.Rows.Add("6", "2", "Nice", "4", "True");
            dt.Rows.Add("7", "4", "Very Nice", "5", "True");
            dt.Rows.Add("8", "5", "Nice", "4", "True");
            dt.Rows.Add("9", "6", "Nice", "4", "True");
            dt.Rows.Add("10", "7", "Nice", "4", "True");
            dt.Rows.Add("11", "8", "Nice", "4", "True");
            dt.Rows.Add("12", "9", "Nice", "4", "True");
            dt.Rows.Add("13", "10", "Nice", "4", "True");
            dt.Rows.Add("14", "11", "Nice", "4", "True");
            dt.Rows.Add("15", "12", "Nice", "5", "True");
            dt.Rows.Add("16", "2", "Good", "4", "True");
            dt.Rows.Add("17", "2", "Bad", "5", "False");
            dt.Rows.Add("18", "1", "Very Good", "5", "False");
            dt.Rows.Add("19", "2", "Good", "4", "True");
            dt.Rows.Add("20", "2", "Bad", "5", "False");
            dt.Rows.Add("21", "1", "Very Good", "5", "False");
            dt.Rows.Add("22", "2", "Good", "4", "True");
            dt.Rows.Add("23", "2", "Bad", "5", "False");
            dt.Rows.Add("24", "2", "Bad", "5", "False");
            dt.Rows.Add("25", "1", "Very Good", "5", "False");

            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine("--------------------------------------------------------");
                Console.WriteLine($"{row["ProductId"]}\t|{row["UserId"]}\t|{row["Review"]}\t|{row["Rating"]}\t|{row["Islike"]}");
            }

            Console.WriteLine("");
            IEnumerable<DataRow> rows = dt.AsEnumerable().Where(r => r.Field<string>("Islike") == "True");
            Console.WriteLine("\n-----------Data from datatable who's islike value is true------------");
            Console.WriteLine("");
            foreach (DataRow row in rows)
            {

                Console.WriteLine("--------------------------------------------------------");
                Console.WriteLine($"{row["ProductId"]}\t|{row["UserId"]}\t|{row["Review"]}\t|{row["Rating"]}\t|{row["Islike"]}");
            }
        }

        public void AvgRating(List<ProductReview> list)
        {
            var result = list.GroupBy(info => info.ProducID).Select(group => new { products = group.Key, Count = group.Average(a => a.Rating) });
            foreach (var data in result)
            {
                Console.WriteLine("Product Id:{0} => Average Rating :{1}", data.products, data.Count);
            }
        }


        public void NiceReview(List<ProductReview> list)
        {
            var result = (from productReviews in list where productReviews.Review == "Nice" select productReviews);
            foreach (var data in result)
            {
                Console.WriteLine("ProductID:- " + data.ProducID + " " + "UserID:- " + data.UserID
                      + " " + "Rating:- " + data.Rating + " " + "Review:- " + data.Review + " " + "IsLike:- " + data.isLike);
            }
        }

        public void OneIdData(List<ProductReview> list)
        {
            var result = (from productReviews in list where productReviews.UserID == 10 select productReviews).OrderBy(x => x.Rating);
            foreach (var data in result)
            {
                Console.WriteLine("ProductID:- " + data.ProducID + " " + "UserID:- " + data.UserID
                      + " " + "Rating:- " + data.Rating + " " + "Review:- " + data.Review + " " + "IsLike:- " + data.isLike);
            }
        }
    }
}

