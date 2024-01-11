
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Net.Sockets;
using System.Net;
namespace Rumour_riding
{
 public partial class loginkey : Form
 {
 string id; string destid; string syscon; string ukey; string flp; string flsz;
 string f; string g; string org; string node; string pathf; string s11;
 string strfilepath;
 string ip = Dns.GetHostName();
 public loginkey(string str, string str1, string str2, string str3, string str4, string 
str5,string s,string h,string j,string n,string pf,string r2,string filepath)
 {
 id = str.ToString();
 destid = str1.ToString();
 ukey = str2.ToString();
 syscon = str3.ToString();
 flp = str4.ToString();

 flsz = str5.ToString();
 f = s.ToString();
 g = h.ToString();
 org = j.ToString();
 node = n.ToString();
 pathf = pf.ToString();
 s11 = r2.ToString();
 strfilepath = filepath.ToString()
 InitializeComponent();
 }
 SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;;Initial 
Catalog=rumour; Integrated Security=true;");
 IPAddress ipad = IPAddress.Parse("192.168.1.2");
 string sysname = Dns.GetHostName();
 byte[] b1;
 OpenFileDialog op;
 FileInfo fn; 
 TcpListener list1;
 string rd, v,
 private void button1_Click(object sender, EventArgs e)
 {
 //passdata();
 SqlCommand cmd = new SqlCommand("select node_id,user_key from 
rumour_details where user_key='" + textBox1.Text + "' and node_id='" + 
textBox2.Text + "'", con);
 con.Open();
 SqlDataReader dr = cmd.ExecuteReader();
 if (dr.Read())
 {
 sending();

 }
 else
 {
 MessageBox.Show("Enter your key");
 }
 con.Close() 
 }
 public void passdata()
 {
 string s = org.ToString();
 TcpClient client = new TcpClient("" + s + "", 5050);
 StreamWriter sw = new StreamWriter(client.GetStream());
 sw.WriteLine(ip);
 sw.Flush();
 list1 = new TcpListener(4040);
 // list1 = new TcpListener(, 4040);
 list1.Start();
 TcpClient client1 = list1.AcceptTcpClient();
 MessageBox.Show("Ready to send data");
 StreamReader sr = new StreamReader(client1.GetStream());
 rd = sr.ReadLine();
 //v = rd.ToString();
 textBox1.Text = rd.ToString();
 list1.Stop();
 client1.Close();
 send_form sf = new send_form(id, destid, ukey, syscon, flp, flsz, f, g, org, 
node,pathf,strfilepath);
 sf.Show();
 }

 public void passdata1()
 {
 //string s1 = org.ToString();
 TcpClient client = new TcpClient("" + s11 + "", 5051);
 StreamWriter sw = new StreamWriter(client.GetStream());
 sw.WriteLine(ip);
 sw.Flush();
 list1 = new TcpListener(4041)