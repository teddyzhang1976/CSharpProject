using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Profile;

namespace StateSample
{
  public class ProfileCommon1 : ProfileBase
  {
    public virtual string Name
    {
      get
      {
        return (string)this["Name"];
      }
      set
      {
        this["Name"] = value;
      }
    }

    public virtual string Color
    {
      get
      {
        return (string)this.GetPropertyValue("Color");
      }
      set
      {
        this.SetPropertyValue("Color", value);
      }
    }

    public virtual ShoppingCart ShoppingCart
    {
      get { return this["ShoppingCart"] as ShoppingCart; }
      set { this["ShoppingCart"] = value; }
    }

    public virtual ProfileCommon1 GetProfile(string username)
    {
      return ((ProfileCommon1)(ProfileBase.Create(username)));
    }
    
  }

}