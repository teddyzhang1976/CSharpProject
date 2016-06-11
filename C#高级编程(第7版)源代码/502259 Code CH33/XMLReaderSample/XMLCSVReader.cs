#region Using directives

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

#endregion

namespace XMLSample
{
  public class XmlCSVReader : XmlTextReader
  {
    public enum elementNames
    {
      lastName = 0,
      firstName = 1,
      addressLin1 = 2,
      adressLine3 = 3,
      city = 4,
      st = 5,
      zip = 6
    }

    XmlNodeType _nodeType = XmlNodeType.None;
    StreamReader _sr;
    string _line;
    string _name;
    string _value;
    int _elementCtr = 0;
    string[] _lineArray = new string[7];
    bool _init = false;

    public XmlCSVReader(string file)  : base()
    {
      _sr = new StreamReader(file);
      
    }



    public override bool Read()
    {
      //if (_elementCtr < _lineArray.Length)
      //{
        if (!_init)
        {
          _line = _sr.ReadLine();
          if (_line != null)
          {
            _lineArray = _line.Split(',');
            _nodeType = XmlNodeType.Element;
            _name = Enum.GetName(typeof(elementNames), 0);
            _init = true;

          }
          else
          {
            _init = false;
            _elementCtr = 0;
          }
          return _init;
        }

        if (_nodeType == XmlNodeType.Text)
        {
          //this marks the end of the element
          _nodeType = XmlNodeType.EndElement;
        }
        else if (_nodeType == XmlNodeType.Element)
        {
          //This is setting the Text property
          _nodeType = XmlNodeType.Text;
          _value = _lineArray[_elementCtr];
        }
        else if (_nodeType == XmlNodeType.EndElement)
        {
          //this starts the next element
          _nodeType = XmlNodeType.Element;
          _value = "";
          if (_elementCtr == _lineArray.Length - 1)
          {
            _init = false;
            _elementCtr = 0;
          }
          else
            _elementCtr++;
        }
        return true;

      //}
      //_init = false;
      //return _init;
//
//
//      int tmpPos;
//      bool lineStart = false;
//
//      if (_elementCtr < 6)
//      {
//        if (_curPos == 0)
//        {
//          _line = _sr.ReadLine();
//          _curPos = 0;
//          _elementCtr = 0;
//          lineStart = true;
//        }
//
//        if (_nodeType == XmlNodeType.Text)
//        {
//          _nodeType = XmlNodeType.EndElement;
//          _elementCtr++;
//        }
//        else if (_line.Substring(_curPos, 1) == "," || _curPos == 0)
//        {
//          _nodeType = XmlNodeType.Element;
//          _name = Enum.GetName(typeof(elementNames), _elementCtr);
//          _curPos++;
//        }
//        else if (_nodeType == XmlNodeType.Element)
//        {
//          _nodeType = XmlNodeType.Text;
//          tmpPos = _line.IndexOf(',', _curPos);
//          if (tmpPos == -1)
//            _value = _line.Substring(_curPos);
//          else
//            _value = _line.Substring(_curPos, tmpPos - _curPos);
//          
//          _curPos = tmpPos;
//        }
//        return true;
//      }
//      else
//        return false;
    }

    public override XmlNodeType NodeType
    {
      get { return _nodeType; }
    }



    public override string Name
    {
      get { return _name; }
    }

    public override string Value
    {
      get { return _value; }
    }



  }
}
