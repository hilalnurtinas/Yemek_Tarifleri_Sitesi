﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace YemekTarifleriSitem
{
    public partial class HakkimizdaAdmin : System.Web.UI.Page
    {
        sqlSinif bgl = new sqlSinif();
        protected void Page_Load(object sender, EventArgs e)
        {
            Panel2.Visible = false;

            if (Page.IsPostBack==false)
            {
                SqlCommand komut = new SqlCommand("Select * From Tbl_Hakkimizda", bgl.baglanti());
                SqlDataReader dataReader = komut.ExecuteReader();
                while (dataReader.Read())
                {
                    TextBox1.Text = dataReader[0].ToString();
                }
                bgl.baglanti().Close();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Panel2.Visible = true;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Panel2.Visible = false;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update Tbl_Hakkimizda Set Metin=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TextBox1.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
        }
    }
}