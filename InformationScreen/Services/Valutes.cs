using System.Collections.Generic;
using System.Xml.Serialization;

namespace InformationScreen.Services;

[XmlRoot(ElementName="Valute")]
public class Valute { 

  [XmlElement(ElementName="NumCode")] 
  public int NumCode { get; set; } 

  [XmlElement(ElementName="CharCode")] 
  public string? CharCode { get; set; } 

  [XmlElement(ElementName="Nominal")] 
  public int Nominal { get; set; } 

  [XmlElement(ElementName="Name")] 
  public string? Name { get; set; } 

  [XmlElement(ElementName="Value")] 
  public string? Value { get; set; } 

  [XmlAttribute(AttributeName="ID")] 
  public string? Id { get; set; } 

  [XmlText] 
  public string? Text { get; set; } 
}

[XmlRoot(ElementName="ValCurs")]
public class Valutes { 

  [XmlElement(ElementName="Valute")] 
  public List<Valute>? Valute { get; set; } 

  [XmlAttribute(AttributeName="Date")] 
  public string? Date { get; set; } 

  [XmlAttribute(AttributeName="name")] 
  public string? Name { get; set; } 

  [XmlText] 
  public string? Text { get; set; } 
}