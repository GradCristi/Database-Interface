using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
// added all the librarires neccesary to implement this project


namespace InterfataBD_Csharp
{
    public partial class RentCycleDatabase : MaterialForm           // this part contains the materials i used to make the interface a bit prettier
    {
        public RentCycleDatabase()
        {
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;                     //this is the logo that is resent in the top left corner

            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;                //i used the dark theme, i found it was a bit easier to read

            // Configure color schema
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue400, Primary.Blue500,
                Primary.Blue500, Accent.LightBlue200,
                TextShade.WHITE
            );
        }




 
        private void pictureBox1_Click_1(object sender, EventArgs e)  //i do not need anything from the click action
        {

        }

        private void materialLabel1_Click(object sender, EventArgs e)
        {

        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)        //the first button
        {
            //we need to open the connection to our machin(the data source), place the ProiectBD as the location of our tables, and integrated security as 
            //SSPI because that's what i found worked :))
            string connectionString;
            SqlConnection cnn;                                                                          //this is the connection, we will open this later
            connectionString = @"data source= DESKTOP-R47JQ7V\SQLEXPRESS; initial catalog=ProiectBD; Integrated Security=SSPI;";        
            cnn = new SqlConnection(connectionString);                                                  //we open the connection of connectionString
            cnn.Open();
            SqlCommand command;                                                                         // SqlCommand is a class used to perform operations in C#
            SqlDataReader dataReader;                                                                   //it reads the data to be used at output
            String sql, Output = "";
            sql = "Select Nume, Prenume, CNP, Telefon, Salariu from dbo.Angajati";                      //the query itself, we want to display the employees
            command = new SqlCommand(sql, cnn);                                                         //the command object, with the sql string, and conection as parameters
            dataReader = command.ExecuteReader();                                                       //executing the command, so reader will contain the data we need

            while (dataReader.Read())                                                                   //using a while to read all the elements in the dataReader
            {   //Output acts as our sentence creator, being inlayed with data from the reader, in order. We want to display 5 columns, so we need 5 elements from 0-4 to be read into the output
                Output = Output + dataReader.GetValue(0) + "-" + dataReader.GetValue(1) + ", CNP: " + dataReader.GetValue(2) + ", Telefon: " + dataReader.GetValue(3) + ", Salariu: " + dataReader.GetValue(4) + " " + "\n";

            }
            MessageBox.Show(Output);                                                                    //propagates the output to the message box 
            dataReader.Close();
            command.Dispose();
            cnn.Close();                                                                                // we close all our opened connections and variables
        }

        private void materialLabel2_Click(object sender, EventArgs e)
        {

        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            //this button makes sure the connection is actually succesful. It displays connection is succesful if everything went ok, gives an error if not
            string connectionString;
            SqlConnection cnn;
            connectionString = @"data source= DESKTOP-R47JQ7V\SQLEXPRESS; initial catalog=ProiectBD; Integrated Security=SSPI;";
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            MessageBox.Show("Connection is succesful");
            cnn.Close();
        }

        private void materialRaisedButton1_Click_1(object sender, EventArgs e)
        {
            //same basic concept as the employees button, only this time customized for the Bicycle domain, we only need to show 4 items here
            string connectionString;
            SqlConnection cnn;
            connectionString = @"data source= DESKTOP-R47JQ7V\SQLEXPRESS; initial catalog=ProiectBD; Integrated Security=SSPI;";
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            SqlCommand command;
            SqlDataReader dataReader;
            String sql, Output = "";
            sql = "Select Nume, Producator, Tip_Bicicleta, Pret from dbo.Biciclete";
            command = new SqlCommand(sql, cnn);
            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                Output = Output + dataReader.GetValue(0) + "-" + dataReader.GetValue(1) + "-" + dataReader.GetValue(2) + "-" + dataReader.GetValue(3) + "\n";

            }
            MessageBox.Show(Output);
            dataReader.Close();
            command.Dispose();
            cnn.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

     

 
        private void materialSingleLineTextField3_Click(object sender, EventArgs e)
        {

        }

        private void materialSingleLineTextField4_Click(object sender, EventArgs e)
        {

        }


        private void materialRaisedButton2_Click_1(object sender, EventArgs e)
        {
            //we want to insert into the employees table, the data contained in the text boxes 1-4 and 16(16 is because i forgot to add a field and i added it later)
            string conString = @"data source= DESKTOP-R47JQ7V\SQLEXPRESS; initial catalog=ProiectBD; Integrated Security=SSPI;";
            SqlConnection con = new SqlConnection(conString);

            //opening the connection
            con.Open();

            SqlCommand command;
            string sql;
            //Using the SQL syntax, we insert into the corresponding columns the values @nume, @prenume etc, which will be added via the text box 
            sql = "INSERT INTO dbo.Angajati (Nume, Prenume, CNP, Telefon, Salariu) VALUES (@nume, @prenume, @cnp, @telefon, @salariu)";

            //command statement
            command = new SqlCommand(sql, con);

            //We are assigning the variables @nume, @prenume, @cnp, the values containted in the fields, so we can use them in the query
            command.Parameters.Add("@nume", SqlDbType.VarChar).Value = materialSingleLineTextField1.Text;
            command.Parameters.Add("@prenume", SqlDbType.VarChar).Value = materialSingleLineTextField2.Text;
            command.Parameters.Add("@cnp", SqlDbType.VarChar).Value = materialSingleLineTextField3.Text;
            command.Parameters.Add("@telefon", SqlDbType.VarChar).Value = materialSingleLineTextField4.Text;
            command.Parameters.Add("@salariu", SqlDbType.Int).Value = materialSingleLineTextField16.Text;
            command.ExecuteNonQuery();

            command.Dispose();
            materialSingleLineTextField1.Clear();           //i wanted to clear the fields after completing an interrogation, because it seems to me like it's a good ideea
            materialSingleLineTextField2.Clear();
            materialSingleLineTextField3.Clear();
            materialSingleLineTextField4.Clear();
            materialSingleLineTextField16.Clear();
            con.Close();

        }

        private void materialSingleLineTextField1_Click(object sender, EventArgs e)
        {

        }

        private void materialRaisedButton3_Click(object sender, EventArgs e)
        {
            //Reading and displaying the elements for the Clients table, using the same process as above
            string connectionString;
            SqlConnection cnn;
            connectionString = @"data source= DESKTOP-R47JQ7V\SQLEXPRESS; initial catalog=ProiectBD; Integrated Security=SSPI;";
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            SqlCommand command;
            SqlDataReader dataReader;
            String sql, Output = "";
            sql = "Select Nume, Prenume, CNP, Telefon from dbo.Clienti";
            command = new SqlCommand(sql, cnn);
            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                Output = Output + dataReader.GetValue(0) + "-" + dataReader.GetValue(1) + ", CNP: " + dataReader.GetValue(2) + ", Telefon: " + dataReader.GetValue(3) + "\n";

            }
            MessageBox.Show(Output);
            dataReader.Close();
            command.Dispose();
            cnn.Close();

        }

        private void materialRaisedButton4_Click(object sender, EventArgs e)
        {
            // we want to insert into Clients the data that was inserted into our text fields
            string conString = @"data source= DESKTOP-R47JQ7V\SQLEXPRESS; initial catalog=ProiectBD; Integrated Security=SSPI;";
            SqlConnection con = new SqlConnection(conString);

            con.Open();

            SqlCommand command;
            string sql;
            //same concept as above, we insert the values @nume, @prenume, @cnp, @telefon
            sql = "INSERT INTO dbo.Clienti (Nume, Prenume, CNP, Telefon) VALUES (@nume, @prenume, @cnp, @telefon)";

            command = new SqlCommand(sql, con);
            //The values mentioned above take their contents from the single line text fields
            command.Parameters.Add("@nume", SqlDbType.VarChar).Value = materialSingleLineTextField5.Text;
            command.Parameters.Add("@prenume", SqlDbType.VarChar).Value = materialSingleLineTextField6.Text;
            command.Parameters.Add("@cnp", SqlDbType.VarChar).Value = materialSingleLineTextField7.Text;
            command.Parameters.Add("@telefon", SqlDbType.VarChar).Value = materialSingleLineTextField8.Text;
            command.ExecuteNonQuery();
           
            command.Dispose();
            materialSingleLineTextField5.Clear();               //we clear the text fields after use
            materialSingleLineTextField6.Clear();
            materialSingleLineTextField7.Clear();
            materialSingleLineTextField8.Clear();
            con.Close();
        }

        private void materialRaisedButton5_Click(object sender, EventArgs e)
        {
            string conString = @"data source= DESKTOP-R47JQ7V\SQLEXPRESS; initial catalog=ProiectBD; Integrated Security=SSPI;";
            SqlConnection con = new SqlConnection(conString);

            con.Open();

            SqlCommand command;
            string sql, Output="";
            SqlDataReader dataReader;
                                                                                                
            sql = "Select Nume, Prenume, CNP, Telefon from dbo.Angajati where CNP=@cnp";        //we want to search the employees table, for the exact CNP that was given

            command = new SqlCommand(sql, con);

            command.Parameters.Add("@cnp", SqlDbType.VarChar).Value = materialSingleLineTextField9.Text;        //we take the varchar value in our text field to search against
            command.ExecuteNonQuery();
            dataReader = command.ExecuteReader();
            command.Dispose();
            while (dataReader.Read())
            {
                Output = Output + dataReader.GetValue(0) + "-" + dataReader.GetValue(1) + ", CNP: " + dataReader.GetValue(2) +  ", Telefon: "+ dataReader.GetValue(3) + "\n";

            }
            MessageBox.Show(Output);
            dataReader.Close();
            materialSingleLineTextField9.Clear();                                   //we clear our text box after completing
            con.Close();

        }

        private void materialSingleLineTextField9_Click(object sender, EventArgs e)
        {

        }

        private void materialRaisedButton6_Click(object sender, EventArgs e)
        {
            //deleting a certain entry from the table, based on a personal numerical code, this process is overall similar to the one above where we selected based on the same principle
            string conString = @"data source= DESKTOP-R47JQ7V\SQLEXPRESS; initial catalog=ProiectBD; Integrated Security=SSPI;";
            SqlConnection con = new SqlConnection(conString);

            con.Open();

            SqlCommand command;
            string sql;

            sql = "Delete dbo.Angajati where CNP=@cnp";             //SQL Statement, we want to delete that entry with the corresponding CNP

            command = new SqlCommand(sql, con);

            command.Parameters.Add("@cnp", SqlDbType.VarChar).Value = materialSingleLineTextField9.Text;
            command.ExecuteNonQuery();
            command.Dispose();
            materialSingleLineTextField9.Clear();
            con.Close();
        }

        private void materialRaisedButton7_Click(object sender, EventArgs e)
        {
            // we want to search a specific type of bike, based on the type it is
            string conString = @"data source= DESKTOP-R47JQ7V\SQLEXPRESS; initial catalog=ProiectBD; Integrated Security=SSPI;";
            SqlConnection con = new SqlConnection(conString);

            con.Open();

            SqlCommand command;
            string sql, Output = "";
            SqlDataReader dataReader;
            // we select everything we want from it, based on matching bicycle type
            sql = "Select Nume, Producator, Dimensiune_Roti, Categorie_Pret, Pret from dbo.Biciclete where Tip_Bicicleta=@tip";

            command = new SqlCommand(sql, con);

            command.Parameters.Add("@tip", SqlDbType.VarChar).Value = materialSingleLineTextField10.Text;
            command.ExecuteNonQuery();
            dataReader = command.ExecuteReader();
            command.Dispose();
            while (dataReader.Read())
            {
                Output = Output + "Nume: " + dataReader.GetValue(0) + "Producator: " + dataReader.GetValue(1) + ", Dimensiune Roti: " + dataReader.GetValue(2) + ", Categorie Pret: " + dataReader.GetValue(3) + ", Pret: " + dataReader.GetValue(4) + "\n";

            }
            MessageBox.Show(Output);
            dataReader.Close();
            materialSingleLineTextField10.Clear();
            con.Close();
        }

        private void materialFlatButton2_Click(object sender, EventArgs e)
        {
            //people may change their phone numbers, so i wanted to implement this option 
            string conString = @"data source= DESKTOP-R47JQ7V\SQLEXPRESS; initial catalog=ProiectBD; Integrated Security=SSPI;";
            SqlConnection con = new SqlConnection(conString);

            con.Open();

            SqlCommand command;
            string sql;
            //Sql syntax for updating, tailored for my uses
            sql = "Update dbo.Angajati Set Telefon=@telefon Where CNP=@cnp";  //i chose to base my search on the unique personal identifier CNP because people may have the same names, this way there can be no confusion

            command = new SqlCommand(sql, con);

            //we take the CNP and new phone number from the corresponding text fields, the other text fields are unneccesary in this case.
            command.Parameters.Add("@cnp", SqlDbType.VarChar).Value = materialSingleLineTextField3.Text;
            command.Parameters.Add("@telefon", SqlDbType.VarChar).Value = materialSingleLineTextField4.Text;
            command.ExecuteNonQuery();

            command.Dispose();
            materialSingleLineTextField1.Clear();
            materialSingleLineTextField2.Clear();
            materialSingleLineTextField3.Clear();
            materialSingleLineTextField4.Clear();
            con.Close();
        }

        private void materialFlatButton3_Click(object sender, EventArgs e)
        {
            //virtually identical process as the one for employees
            string conString = @"data source= DESKTOP-R47JQ7V\SQLEXPRESS; initial catalog=ProiectBD; Integrated Security=SSPI;";
            SqlConnection con = new SqlConnection(conString);

            con.Open();

            SqlCommand command;
            string sql;

            sql = "Update dbo.Clienti Set Telefon=@telefon Where CNP=@cnp";
            command = new SqlCommand(sql, con);


            command.Parameters.Add("@cnp", SqlDbType.VarChar).Value = materialSingleLineTextField7.Text;
            command.Parameters.Add("@telefon", SqlDbType.VarChar).Value = materialSingleLineTextField8.Text;
            command.ExecuteNonQuery();

            command.Dispose();
            materialSingleLineTextField5.Clear();
            materialSingleLineTextField6.Clear();
            materialSingleLineTextField7.Clear();
            materialSingleLineTextField8.Clear();
            con.Close();
        }

        private void materialLabel5_Click(object sender, EventArgs e)
        {

        }

        private void materialRaisedButton8_Click(object sender, EventArgs e)
        {
            // we need to be able to place orders into our tables, and this is done in a two step process, as i could not make it a single one
            //the first step is to add the IDs of the Employee and Client into the Order table. We use the CNP to search for the corresponding
            //employee and client, then perform a search in a cross joined version of both tables( i used the cross join to be able to work on 
            //a complete version of both tables at the same time
            string conString = @"data source= DESKTOP-R47JQ7V\SQLEXPRESS; initial catalog=ProiectBD; Integrated Security=SSPI;";
            SqlConnection con = new SqlConnection(conString);

            con.Open();

            SqlCommand command;
            string sql;
            // we want to insert into Orders(Comenzi) the corresponding IDs to the cnp identifiers present at the text fields
            sql = "INSERT INTO dbo.Comenzi (ID_Angajat, ID_Client) SELECT ID_Angajat, ID_Client FROM Angajati A Cross JOIN Clienti C Where A.CNP = @cnpangajat AND C.CNP = @cnpclient";
            command = new SqlCommand(sql, con);

            command.Parameters.Add("@cnpangajat", SqlDbType.VarChar).Value = materialSingleLineTextField11.Text;
            command.Parameters.Add("@cnpclient", SqlDbType.VarChar).Value = materialSingleLineTextField12.Text;
            command.ExecuteNonQuery();

            command.Dispose();

            //this being a two step process, i decided against erasing the text fields after this operation, they shall be erased after the 2nd stage is completed

            con.Close();
        }

        private void materialRaisedButton9_Click(object sender, EventArgs e)
        {
            //this button corresponds to the Supported table in our DB, (despite the fact that its the next button, and normal procedures would have them one after another
            //but i had some conceptual issues with the 2nd stage of my adding Order procedure, so i did this first)
            string conString = @"data source= DESKTOP-R47JQ7V\SQLEXPRESS; initial catalog=ProiectBD; Integrated Security=SSPI;";
            SqlConnection con = new SqlConnection(conString);

            con.Open();

            SqlCommand command;
            string sql;
            // we want to insert into the Supported table the ID of the employee and the age of the supported person , so we make a SELECT based on ID_Angajat and @varsta, to achieve this
            sql = "INSERT INTO dbo.Intretinuti (ID_Angajat, Varsta) SELECT A.ID_Angajat, @varsta FROM Angajati A WHERE A.CNP= @cnp";
      
            command = new SqlCommand(sql, con);

        
            command.Parameters.Add("@varsta", SqlDbType.VarChar).Value = materialSingleLineTextField14.Text;
            command.Parameters.Add("@cnp", SqlDbType.VarChar).Value = materialSingleLineTextField9.Text;
            command.ExecuteNonQuery();

            command.Dispose();
            materialSingleLineTextField14.Clear();
            materialSingleLineTextField9.Clear();
            con.Close();

        }

        private void materialRaisedButton10_Click(object sender, EventArgs e)
        {
            //the 2nd stage of the placing order process is a bit different, and it required a subquery to fix 
            string conString = @"data source= DESKTOP-R47JQ7V\SQLEXPRESS; initial catalog=ProiectBD; Integrated Security=SSPI;";
            SqlConnection con = new SqlConnection(conString);

            con.Open();

            SqlCommand command;
            string sql;
            //I needed to insert into the Order_Bicycle table the ID of the order and that of the Bicycle, so I created a subquery where I select the last placed order ID( because i will never need another but the last entry, since it's the 2nd stage in a two stage process)
            //and we also need to match the Name of the bike with the ID in our DB. Once we have both of those we can insert them into our table
            sql = "INSERT INTO dbo.Comanda_Bicicleta (ID_Comanda, ID_Bicicleta) SELECT ID_Comanda, ID_Bicicleta From Comenzi C CROSS Join Biciclete B WHERE ID_Comanda = (Select Top 1 C.ID_Comanda FROM Comenzi C Order by C.ID_Comanda DESC) AND Nume = @nume";
            command = new SqlCommand(sql, con);

            command.Parameters.Add("@nume", SqlDbType.VarChar).Value = materialSingleLineTextField13.Text;
            command.ExecuteNonQuery();

            command.Dispose();


            materialSingleLineTextField11.Clear();
            materialSingleLineTextField12.Clear();
            materialSingleLineTextField13.Clear();          //as promised, we erase the fields after this process is completed
            con.Close();
        }

        //here starts the more query intensive bit of the program

        private void materialRaisedButton11_Click(object sender, EventArgs e)
        {
            //the first bit has us displaying the best performing employees based on the number of succesfully placed orders
            //same stages occur as until now, with the connection, the readying of the read stage, only the query shall differ
            string connectionString;
            SqlConnection cnn;
            connectionString = @"data source= DESKTOP-R47JQ7V\SQLEXPRESS; initial catalog=ProiectBD; Integrated Security=SSPI;";
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            SqlCommand command;
            SqlDataReader dataReader;
            String sql, Output = "";
            //in this case, we need the name, surname and count of orders placed by each employee, so we join the employees table with the orders one, in order to be able to count the times
            //where each employee appears. We also order them, because this is a ranking after all
            sql = "SELECT A.Nume, A.Prenume, Count(C.ID_Angajat) FROM Angajati A Left JOIN Comenzi C ON A.ID_Angajat = C.ID_Angajat GROUP BY A.Nume, A.Prenume ORDER BY Count(C.ID_Angajat) DESC";
            command = new SqlCommand(sql, cnn);
            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                Output = Output + dataReader.GetValue(0) + "-" + dataReader.GetValue(1) + "-" + dataReader.GetValue(2) + "\n";

            }
            MessageBox.Show(Output);
            dataReader.Close();
            command.Dispose();
            cnn.Close();
        }

        private void materialRaisedButton12_Click(object sender, EventArgs e)
        {
            //Following the same competence ranking ideea, we want to find out which bikes have been rented more than 2 times, and place them in order of how many times they have been rented
            //this should offer us an ideea of the ideal bike qualities for our customers, and also the less wished bikes in our current lineup
            string connectionString;
            SqlConnection cnn;
            connectionString = @"data source= DESKTOP-R47JQ7V\SQLEXPRESS; initial catalog=ProiectBD; Integrated Security=SSPI;";
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            SqlCommand command;
            SqlDataReader dataReader;
            String sql, Output = "";
            //We display the Producer, the type and how many times each bicycle has been rented. We need a join with Comanda_Bicicleta to be able count how many times each bike is in the order history.
            //And as advised by the SQL standard, we need to perform a GROUP BY operation on all the columns that are not agregate functions
            sql = "SELECT B.Producator, B.Tip_Bicicleta, B.Nume, COUNT(CB.ID_Bicicleta) FROM Biciclete B left join Comanda_Bicicleta CB on B.ID_Bicicleta = CB.ID_Bicicleta Group by B.Producator, B.Tip_Bicicleta, B.Nume HAVING COUNT(CB.ID_Bicicleta) >= 2 ORDER BY COUNT(CB.ID_Bicicleta) DESC";
            command = new SqlCommand(sql, cnn);
            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                Output = Output + dataReader.GetValue(0) + "-" + dataReader.GetValue(1) + "-" + dataReader.GetValue(2) + "-" + dataReader.GetValue(3) + "\n";

            }
            MessageBox.Show(Output);
            dataReader.Close();
            command.Dispose();
            cnn.Close();
        }

        private void materialRaisedButton13_Click(object sender, EventArgs e)
        {
            //Display those customers that have returned to our shop (so having orders >1)
            string connectionString;
            SqlConnection cnn;
            connectionString = @"data source= DESKTOP-R47JQ7V\SQLEXPRESS; initial catalog=ProiectBD; Integrated Security=SSPI;";
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            SqlCommand command;
            SqlDataReader dataReader;
            String sql, Output = "";
            //We need to join Clienti with Comenzi so we can perform a count on the times each client ID popps up.
            sql = "SELECT C.Nume, C.Prenume, Count(Co.ID_Client) FROM Clienti C JOIN Comenzi Co ON C.ID_Client = Co.ID_Client GROUP BY C.Nume, C.Prenume Having Count(Co.ID_Client) > 1";
            command = new SqlCommand(sql, cnn);
            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                Output = Output + dataReader.GetValue(0) + "-" + dataReader.GetValue(1) + "-" + dataReader.GetValue(2) + "\n";

            }
            MessageBox.Show(Output);
            dataReader.Close();
            command.Dispose();
            cnn.Close();
        }

        private void materialRaisedButton14_Click(object sender, EventArgs e)
        {
            //How many familly members is each employee supporting?
            string connectionString;
            SqlConnection cnn;
            connectionString = @"data source= DESKTOP-R47JQ7V\SQLEXPRESS; initial catalog=ProiectBD; Integrated Security=SSPI;";
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            SqlCommand command;
            SqlDataReader dataReader;
            String sql, Output = "";
            sql = "	SELECT A.Nume, A.Prenume, Count(I.ID_Angajat) FROM Angajati A Left JOIN Intretinuti I ON A.ID_Angajat = I.ID_Angajat GROUP BY A.Nume, A.Prenume ORDER BY Count(I.ID_Angajat) DESC";
            command = new SqlCommand(sql, cnn);
            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                Output = Output + dataReader.GetValue(0) + "-" + dataReader.GetValue(1) + "-" + dataReader.GetValue(2) + "\n";

            }
            MessageBox.Show(Output);
            dataReader.Close();
            command.Dispose();
            cnn.Close();
        }

        private void materialRaisedButton15_Click(object sender, EventArgs e)
        {
            //Which employee placed the order for a specific customer? 
            string conString = @"data source= DESKTOP-R47JQ7V\SQLEXPRESS; initial catalog=ProiectBD; Integrated Security=SSPI;";
            SqlConnection con = new SqlConnection(conString);

            con.Open();

            SqlCommand command;
            string sql, Output = "";
            SqlDataReader dataReader;
            //display those employees whose ID is the same one as the one that placed the order for the customer with CNP = x. The subquery lets me avoid searching by ID, as we were advised not to do.
            sql = "SELECT A.Nume, A.Prenume FROM Angajati A JOIN Comenzi C ON A.ID_Angajat = C.ID_Angajat WHERE C.ID_Client =(Select ID_Client FROM Clienti WHERE CNP= @cnp)";

            command = new SqlCommand(sql, con);

  
            command.Parameters.Add("@cnp", SqlDbType.VarChar).Value = materialSingleLineTextField15.Text;
            command.ExecuteNonQuery();
            dataReader = command.ExecuteReader();
            command.Dispose();
            while (dataReader.Read())
            {
                Output = Output + dataReader.GetValue(0) + "-" + dataReader.GetValue(1) + "\n";

            }
            MessageBox.Show(Output);
            dataReader.Close();
            materialSingleLineTextField15.Clear();
            con.Close();
        }

        private void materialRaisedButton16_Click(object sender, EventArgs e)
        {
            //this displays each employee by the total ammount of value on order placed.
            string connectionString;
            SqlConnection cnn;
            connectionString = @"data source= DESKTOP-R47JQ7V\SQLEXPRESS; initial catalog=ProiectBD; Integrated Security=SSPI;";
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            SqlCommand command;
            SqlDataReader dataReader;
            String sql, Output = "";
            //We join all 3 tables into one, and then we can proceed to calculate the SUM of all the steps where the employee is the same. i am not sure if this is the smartest way to go, but it works :D
            sql = "	SELECT A.Nume, A.Prenume, SUM(B.Pret) FROM Angajati A JOIN Comenzi C on A.ID_Angajat = C.ID_Angajat JOIN Comanda_Bicicleta CB on C.ID_Comanda = CB.ID_Comanda JOIN Biciclete B on CB.ID_Bicicleta = B.ID_Bicicleta Group by A.Nume, A.Prenume";
            command = new SqlCommand(sql, cnn);
            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                Output = Output + dataReader.GetValue(0) + "-" + dataReader.GetValue(1) + "-" + dataReader.GetValue(2) + "\n";

            }
            MessageBox.Show(Output);
            dataReader.Close();
            command.Dispose();
            cnn.Close();
        }

        private void materialLabel39_Click(object sender, EventArgs e)
        {

        }

        private void materialRaisedButton17_Click(object sender, EventArgs e)
        {
            //This displays the employee and the salary if his/her salary is above the median of salaries in this company
            string connectionString;
            SqlConnection cnn;
            connectionString = @"data source= DESKTOP-R47JQ7V\SQLEXPRESS; initial catalog=ProiectBD; Integrated Security=SSPI;";
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            SqlCommand command;
            SqlDataReader dataReader;
            String sql, Output = "";
            //the subquery displays the average salary of the employees, thus providing a comparable point for all other employees
            sql = "SELECT A.Nume, A.Prenume, A.Salariu FROM Angajati A GROUP BY A.Nume, A.Prenume, A.Salariu HAVING A.Salariu > (SELECT AVG(Salariu) FROM Angajati)";
            command = new SqlCommand(sql, cnn);
            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                Output = Output + dataReader.GetValue(0) + "-" + dataReader.GetValue(1) + "-" + dataReader.GetValue(2) + "\n";

            }
            MessageBox.Show(Output);
            dataReader.Close();
            command.Dispose();
            cnn.Close();
        }

        private void materialRaisedButton18_Click(object sender, EventArgs e)
        {
            //bicycles whose price is above the median for their respective categories. So the median changes according to the type of bikes provided
            // mountain bikes are more tehnologically advanced, and therefore more expensive
            string conString = @"data source= DESKTOP-R47JQ7V\SQLEXPRESS; initial catalog=ProiectBD; Integrated Security=SSPI;";
            SqlConnection con = new SqlConnection(conString);


            con.Open();

            SqlCommand command;
            string sql, Output = "";
            SqlDataReader dataReader;
            //We select those bicycles, contained in the type mentioned in the text field, and whose value is greater than the median of their category, the category is specified by the text box
            sql = "SELECT B.Nume, B.Pret FROM Biciclete B Where B.Tip_Bicicleta = @tip GROUP BY B.Nume, B.Pret Having B.Pret > (Select AVG(Pret) from Biciclete Where Tip_Bicicleta = @tip)";

            command = new SqlCommand(sql, con);

            command.Parameters.Add("@tip", SqlDbType.VarChar).Value = materialSingleLineTextField17.Text;
            command.ExecuteNonQuery();
            dataReader = command.ExecuteReader();
            command.Dispose();
            while (dataReader.Read())
            {
                Output = Output + dataReader.GetValue(0) + "-" + dataReader.GetValue(1) + "\n";

            }
            MessageBox.Show(Output);
            dataReader.Close();
            materialSingleLineTextField17.Clear();
            con.Close();
        }

        private void materialRaisedButton19_Click(object sender, EventArgs e)
        {
            //name and salary of the 5 top payed employees 
            String connectionString;
            SqlConnection cnn;
            connectionString = @"data source= DESKTOP-R47JQ7V\SQLEXPRESS; initial catalog=ProiectBD; Integrated Security=SSPI;";
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            SqlCommand command;
            SqlDataReader dataReader;
            String sql, Output = "";
            sql = "SELECT Ang.Nume, Ang.Prenume, Ang.Salariu FROM(SELECT TOP 5 A.Nume, A.Prenume, A.Salariu FROM Angajati A ORDER BY A.Salariu DESC) AS Ang";
            command = new SqlCommand(sql, cnn);
            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                Output = Output + dataReader.GetValue(0) + "-" + dataReader.GetValue(1) + "-" + dataReader.GetValue(2) + "\n";

            }
            MessageBox.Show(Output);
            dataReader.Close();
            command.Dispose();
            cnn.Close();
        }

        private void materialRaisedButton20_Click(object sender, EventArgs e)
        {
            //shows that client who has placed orders for more than 1 bicycle at a a time.
            String connectionString;
            SqlConnection cnn;
            connectionString = @"data source= DESKTOP-R47JQ7V\SQLEXPRESS; initial catalog=ProiectBD; Integrated Security=SSPI;";
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            SqlCommand command;
            SqlDataReader dataReader;
            String sql, Output = "";
            //i solved this in 3 stages: First i found those orders which have more than 1 bicycle in their order, after i found those Client IDs which correspond to those orders, and with those IDs i have displayed the name surname and CNP of the paricular client.
            sql = "SELECT CL.Nume, CL.Prenume, CL.CNP FROM Clienti CL WHERE CL.ID_Client IN(SELECT C.ID_Client FROM Comenzi C  WHERE C.ID_Comanda IN (SELECT CB.ID_Comanda FROM Comanda_Bicicleta CB GROUP BY CB.ID_Comanda Having COUNT(CB.ID_Bicicleta) > 1))";
            command = new SqlCommand(sql, cnn);
            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                Output = Output + dataReader.GetValue(0) + "-" + dataReader.GetValue(1)+ ", CNP:"+ dataReader.GetValue(2) + "\n";

            }
            MessageBox.Show(Output);
            dataReader.Close();
            command.Dispose();
            cnn.Close();
        }

        private void materialLabel18_Click(object sender, EventArgs e)
        {

        }

        private void materialLabel41_Click(object sender, EventArgs e)
        {

        }

        private void materialRaisedButton21_Click(object sender, EventArgs e)
        {
            //We need to display the bicycles of the utmost rented value
            String connectionString;
            SqlConnection cnn;
            connectionString = @"data source= DESKTOP-R47JQ7V\SQLEXPRESS; initial catalog=ProiectBD; Integrated Security=SSPI;";
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            SqlCommand command;
            SqlDataReader dataReader;
            String sql, Output = "";
            // First of all we need the ID and the count of times each bicycle appears in the Bicycle Orders tab. After that is completed, we can select the ID of the bike, and the cost of it, and multiply those and obtain the total ammount of value rented.
            sql = "SELECT b.ID_Bicicleta, b.Nume, b.Pret*cb.count as Incasari FROM(SELECT B.ID_Bicicleta, B.Pret, B.Nume FROM Biciclete B) b JOIN(SELECT CB.ID_Bicicleta, COUNT(CB.ID_Bicicleta) AS count FROM Comanda_Bicicleta CB GROUP BY CB.ID_Bicicleta) cb ON b.ID_Bicicleta = cb.ID_Bicicleta ORDER BY Incasari DESC";
            command = new SqlCommand(sql, cnn);
            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                Output = Output + dataReader.GetValue(0) + "-" + dataReader.GetValue(1) + ", Incasari:" + dataReader.GetValue(2) + "\n";

            }
            MessageBox.Show(Output);
            dataReader.Close();
            command.Dispose();
            cnn.Close();
        }
    }
}
