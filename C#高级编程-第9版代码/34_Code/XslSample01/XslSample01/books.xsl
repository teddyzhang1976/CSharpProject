<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
  <xsl:template match="/">
    <HTML>
      <head>
        <title>Price List</title>
      </head>

      <body>
        <table>
          <xsl:apply-templates/>
        </table>

      </body>
    </HTML>

  </xsl:template>

  <xsl:template match="bookstore">
    <xsl:apply-templates select="book"/>
  </xsl:template>

  <xsl:template match="book">
    <tr>
      <td>
        <xsl:value-of select="title"/>
      </td>
      <td>
        <xsl:value-of select="price"/>
      </td>
    </tr>
  </xsl:template>
</xsl:stylesheet>
