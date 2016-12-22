<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
                xmlns:wrox="http://www.wrox.com"
>
  <msxsl:script language="C#" implements-prefix="wrox">

    public double CalcDiscount(double price)
    {
    return (price * .75);
    }

  </msxsl:script>

  <xsl:output method="xml" indent="yes"/>
  <xsl:template match="/">
    <xsl:element name="books">
      <xsl:apply-templates/>
    </xsl:element>
  </xsl:template>

  <xsl:template match="bookstore">
    <xsl:apply-templates select="book"/>
  </xsl:template>

  <xsl:template match="book">
    <xsl:element name="discbook">
      <xsl:element name="booktitle">
        <xsl:value-of select="title"/>
      </xsl:element>
      <xsl:element name ="discprice">
        <xsl:variable name="p" select="price" />
        <xsl:value-of select="wrox:CalcDiscount($p)"/>
      </xsl:element>
    </xsl:element>
  </xsl:template>
</xsl:stylesheet>
