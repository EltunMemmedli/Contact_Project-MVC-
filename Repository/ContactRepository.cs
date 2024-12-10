using Contact_Project_MVC_.Models;
using System.Data.SqlClient;

namespace Contact_Project_MVC_.Repository
{ 
    public class ContactRepository
    {
        private string connectionString = "Data Source=(local);Database=Contact_Application;Integrated Security=sspi;";


        List<Contact> userList = new List<Contact>();

        public List<Contact> GetContacts()
        {

            string Querry = "SELECT ID, Name, Surname FROM Contact;";
            userList.Clear();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(Querry, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string name = reader["Name"].ToString();
                                string surname = reader["Surname"].ToString();
                                int ID = 0;

                                // User_ID'nin doğru bir int olup olmadığını yoxlamaq
                                if (int.TryParse(reader["ID"].ToString(), out ID))
                                {
                                    var user = new Contact(ID, name, surname);
                                    userList.Add(user);
                                }
                                else
                                {
                                    // İstədiyiniz halda, hər hansı bir səhv hallarda nə baş verəcəyini burada idarə edə bilərsiniz
                                    Console.WriteLine("User_ID dəyəri düzgün deyil.");
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Xəta baş verdi: {ex.Message}");
            }

            return this.userList;
        }

        public Contact GetContactByID(int ID)
        {
            if (userList == null || userList.Count == 0)
            {
                GetContacts();
            }

            return userList.FirstOrDefault(c => c.ID == ID);
        }
                                   
    }
}
