<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:template match="/">
		<HTML>
		<head><title></title><STYLE TYPE="text/css">.note { border-bottom: solid; border-bottom-width: 1px} </STYLE></head>
		<Body>
		<B><xsl:value-of select="//Name"></xsl:value-of></B> (Page - <xsl:value-of select="//PageNumber"></xsl:value-of>)
		<Table width="700px" cellspacing="10px">
		<TR><TD class="note">Name:</TD><TD class="note">Date:</TD><TD class="note">Score:</TD></TR>
		</Table>
		<Table Border="0" cellpadding="6" cellspacing="0">
		<xsl:apply-templates select="//Cells" ></xsl:apply-templates>
		</Table>
		</Body>
		</HTML>
	</xsl:template>
	
	<xsl:template match="Cells">
		<TR>
		<xsl:apply-templates select="ProblemCell"></xsl:apply-templates>
		</TR>
	</xsl:template>
	
	
	<xsl:template match="ProblemCell">
		<TD valign="top" height="90">
			<Table width="60px" cellspacing="0">
				<TR>
					<TD></TD>
					<TD align="right"><xsl:value-of select="ValueOne"></xsl:value-of></TD>
				</TR>
				<TR >
					<TD align="right" class="note"><xsl:value-of select="Operator"></xsl:value-of></TD>
					<TD align="right" class="note"><xsl:value-of select="ValueTwo"></xsl:value-of></TD>
				</TR>
				<TR>
					<TD colspan="2" width="60px" align="right" >
					<xsl:value-of select="AnswerValue" />
					
					</TD>

				</TR>
			</Table>
		</TD>
	</xsl:template>
</xsl:stylesheet>

  