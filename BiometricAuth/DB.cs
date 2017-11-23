using System;
using System.Data;
using System.Drawing;
using System.Data.SQLite;

namespace BiometricAuth
{
    class DB
    {

        SQLiteConnection conn;

        public SQLiteConnection getConnection()
        {
            conn = new SQLiteConnection(@"Data Source=" + System.Windows.Forms.Application.StartupPath + "/base.db");

            return conn;
        }

        public DataTable select(string table,string where)
        {
            DataTable dt = new DataTable();
            new SQLiteDataAdapter("select * from " + table + (where.Length > 0 ? (" where " + where) : ""), getConnection()).Fill(dt);
            return dt;
        }

        public Bitmap getBitmapFromTable(string table, string where, string imageField)
        {
            Byte[] bitmapData = Convert.FromBase64String(FixBase64ForImage(select(table, where).Rows[0].Field<string>(imageField).ToString()));
            System.IO.MemoryStream streamBitmap = new System.IO.MemoryStream(bitmapData);
            Bitmap bitImage = new Bitmap((Bitmap)Image.FromStream(streamBitmap));
            return bitImage;
        }
        public string FixBase64ForImage(string Image)
        {
            System.Text.StringBuilder sbText = new System.Text.StringBuilder(Image, Image.Length);
            sbText.Replace("\r\n", String.Empty); sbText.Replace(" ", String.Empty);
            return sbText.ToString();
        }

    }
   
}
