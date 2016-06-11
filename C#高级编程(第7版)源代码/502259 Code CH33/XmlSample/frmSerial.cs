using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace XmlSample
{
  public partial class frmSerial : Form
  {
    public frmSerial()
    {
      InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      //new products object
      Product pd = new Product();
      //set some properties
      pd.ProductID = 200;
      pd.CategoryID = 100;
      pd.Discontinued = false;
      pd.ProductName = "Serialize Objects";
      pd.QuantityPerUnit = "6";
      pd.ReorderLevel = 1;
      pd.SupplierID = 1;
      pd.UnitPrice = 1000;
      pd.UnitsInStock = 10;
      pd.UnitsOnOrder = 0;
      //new TextWriter and XmlSerializer
      TextWriter tr = new StreamWriter("serialprod.xml");
      XmlSerializer sr = new XmlSerializer(typeof(Product));
      //serialize object
      sr.Serialize(tr, pd);
      tr.Close();
      webBrowser1.Navigate(AppDomain.CurrentDomain.BaseDirectory + "serialprod.xml");
    }

    private void button2_Click(object sender, EventArgs e)
    {
      //create a reference to producst type
      Product newPd;
      //new filestream to open serialized object
      FileStream f = new FileStream("serialprod.xml", FileMode.Open);
      //new serializer
      XmlSerializer newSr = new XmlSerializer(typeof(Product));
      //deserialize the object
      newPd = (Product)newSr.Deserialize(f);
      f.Close();
      MessageBox.Show(newPd.ToString());
    }

    private void button3_Click(object sender, EventArgs e)
    {
      //create new book and bookproducts objects
      Product newProd = new Product();
      BookProduct newBook = new BookProduct();
      //set som eproperties
      newProd.ProductID = 100;
      newProd.ProductName = "Product Thing";
      newProd.SupplierID = 10;

      newBook.ProductID = 101;
      newBook.ProductName = "How to Use Your New Product Thing";
      newBook.SupplierID = 10;
      newBook.ISBN = "123456789";
      //add the items to an array
      Product[] addProd ={ newProd, newBook };
      //new inventory object using the addProd array
      Inventory inv = new Inventory();
      inv.InventoryItems = addProd;
      //serialize the Inventory object
      TextWriter tr = new StreamWriter("order.xml");
      XmlSerializer sr = new XmlSerializer(typeof(Inventory));

      sr.Serialize(tr, inv);
      tr.Close();
      webBrowser1.Navigate(AppDomain.CurrentDomain.BaseDirectory + "order.xml");
    }

    private void button4_Click(object sender, EventArgs e)
    {
      //create the XmlAttributes boject
      XmlAttributes attrs = new XmlAttributes();
      //add the types of the objects that will be serialized
      attrs.XmlElements.Add(new XmlElementAttribute("Book", typeof(BookProduct)));
      attrs.XmlElements.Add(new XmlElementAttribute("Product", typeof(Product)));
      XmlAttributeOverrides attrOver = new XmlAttributeOverrides();
      //add to the attributes collection
      attrOver.Add(typeof(Inventory), "InventoryItems", attrs);
      //create the Product and Book objects
      Product newProd = new Product();
      BookProduct newBook = new BookProduct();

      newProd.ProductID = 100;
      newProd.ProductName = "Product Thing";
      newProd.SupplierID = 10;

      newBook.ProductID = 101;
      newBook.ProductName = "How to Use Your New Product Thing";
      newBook.SupplierID = 10;
      newBook.ISBN = "123456789";

      Product[] addProd ={ newProd, newBook };

      Inventory inv = new Inventory();
      inv.InventoryItems = addProd;
      TextWriter tr = new StreamWriter("inventory.xml");
      XmlSerializer sr = new XmlSerializer(typeof(Inventory), attrOver);

      sr.Serialize(tr, inv);
      tr.Close();
      webBrowser1.Navigate(AppDomain.CurrentDomain.BaseDirectory + "inventory.xml");

    }

    private void button5_Click(object sender, EventArgs e)
    {
        //create the new XmlAttributes collection
   XmlAttributes attrs=new XmlAttributes();

   //add the type information to the elements collection
   attrs.XmlElements.Add(new XmlElementAttribute("Book", typeof(BookProduct)));
   attrs.XmlElements.Add(new XmlElementAttribute("Product",typeof(Product)));
  
   XmlAttributeOverrides attrOver=new XmlAttributeOverrides();

   //add to the Attributes collection
   attrOver.Add(typeof(Inventory),"InventoryItems",attrs);
  
   //need a new Inventory object to deserialize to    
   Inventory newInv;
  
   //deserialize and load data into the listbox from deserialized object
   FileStream f=new FileStream("inventory.xml",FileMode.Open);
   XmlSerializer newSr=new XmlSerializer(typeof(Inventory),attrOver);
  
   newInv=(Inventory)newSr.Deserialize(f);
        MessageBox.Show(newInv.ToString());
    }
  }


    //class that will be serialized.
    //attributes determine how object is serialized
    [System.Xml.Serialization.XmlRootAttribute()]
      public class Product {
        private int prodId;
        private string prodName;
        private int suppId;
        private int catId;
        private string qtyPerUnit;
        private Decimal unitPrice;
        private short unitsInStock;
        private short unitsOnOrder;
        private short reorderLvl;
        private bool discont;
        private int disc;

        //added the Discount attribute
        [XmlAttributeAttribute(AttributeName="Discount")]
        public int Discount {
          get {return disc;}
          set {disc=value;}
        }
   
        [XmlElementAttribute()]
        public int  ProductID {
          get {return prodId;}
          set {prodId=value;}
        }
        [XmlElementAttribute()]
        public string ProductName {
          get {return prodName;}
          set {prodName=value;}
        }
        [XmlElementAttribute()]
        public int SupplierID {
          get {return suppId;}
          set {suppId=value;}
        }
  
        [XmlElementAttribute()]
        public int CategoryID {
          get {return catId;}
          set {catId=value;}
        }
   
        [XmlElementAttribute()]
        public string QuantityPerUnit {
          get {return qtyPerUnit;}
          set {qtyPerUnit=value;}
        }
   
        [XmlElementAttribute()]
        public Decimal UnitPrice {
          get {return unitPrice;}
          set {unitPrice=value;}
        }

        [XmlElementAttribute()]
        public short UnitsInStock {
          get {return unitsInStock;}
          set {unitsInStock=value;}
        }
   
        [XmlElementAttribute()]
        public short UnitsOnOrder {
          get {return unitsOnOrder;}
          set {unitsOnOrder=value;}
        }
   
        [XmlElementAttribute()]
        public short ReorderLevel {
          get {return reorderLvl;}
          set {reorderLvl=value;}
        }
  
        [XmlElementAttribute()]
        public bool Discontinued {
          get {return discont;}
          set {discont=value;}
        }

public override string ToString()
{
    StringBuilder outText = new StringBuilder();
    outText.Append(prodId);
    outText.Append("\r\n");
    outText.Append(prodName);
    outText.Append("\r\n ");
    outText.Append(unitPrice);
    return outText.ToString();
}
      }


  public class Inventory
  {

    private Product[] stuff;
    //ctor
    public Inventory() { }
    //need have an attribute entry for each data type
    [XmlArrayItem("Prod", typeof(Product)),
    XmlArrayItem("Book", typeof(BookProduct))]

    public Product[] InventoryItems
    {
      get { return stuff; }
      set { stuff = value; }
    }

    public override string ToString()
    {
        StringBuilder outText = new StringBuilder();
        foreach (Product prod in stuff)
        {
            outText.Append(prod.ProductName);
            outText.Append("\r\n");
        }
        return outText.ToString();
    }
  }

  public class BookProduct : Product
  {
    private string isbnNum;

    public BookProduct() { }

    public string ISBN
    {
      get { return isbnNum; }
      set { isbnNum = value; }
    }

  }
}