namespace DisposeTest
{
    [System.Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    [System.Xml.Serialization.XmlRoot(Namespace = "", IsNullable = false)]
    public partial class Bookstore
    {
        private BookstoreBook bookField;

        public BookstoreBook Book
        {
            get => bookField;
            set => bookField = value;
        }
    }

    [System.Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class BookstoreBook
    {
        private BookstoreBookTitle titleField;

        private string authorField;

        private ushort yearField;

        private decimal priceField;

        private string categoryField;

        public BookstoreBookTitle title
        {
            get => titleField;
            set => titleField = value;
        }

        public string Author
        {
            get => authorField;
            set => authorField = value;
        }

        public ushort Year
        {
            get => yearField;
            set => yearField = value;
        }

        public decimal Price
        {
            get => priceField;
            set => priceField = value;
        }

        [System.Xml.Serialization.XmlAttribute()]
        public string Category
        {
            get => categoryField;
            set => categoryField = value;
        }
    }

    [System.Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class BookstoreBookTitle
    {

        private string langField;
        private string valueField;

        [System.Xml.Serialization.XmlAttribute()]
        public string Lang
        {
            get => langField;
            set => langField = value;
        }

        [System.Xml.Serialization.XmlText()]
        public string Value
        {
            get => valueField;
            set => valueField = value;
        }
    }
}
