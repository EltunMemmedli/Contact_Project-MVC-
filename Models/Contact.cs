namespace Contact_Project_MVC_.Models
{ 
    public class Contact
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public Contact(int id, string name, string surname)
        {
            this.ID = id;
            this.Name = name;
            this.Surname = surname;
        }
    }
}
