<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PreRegistro.aspx.cs" Inherits="Sitio.Pregistro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="es">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Pregistro </title>
    <meta charset="utf-8"/>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge">

    <meta name="keywords" content="Amor y Restauración Cuatitlan Izcalli " />
    <meta name="description" content="Amor y Restauración Cuatitlan Izcalli">
    <meta name="viewport"  content="width=device-width, user-scalable=no, initial-scale=1, maximum-scale=1"/>

    <meta name="msapplication-tap-highlight" content="no" />
    <meta name="robots" content="index,follow,all" />
    <meta name="author" content="Francisco Garcia | STI" />

    <link rel="shortcut icon" href="Comun/favicon/Aplicacion.ico" type="image/x-icon">
    <link rel="icon" href="Comun/favicon/Aplicacion.ico" type="image/x-icon">

    <meta property="og:title" content="Amor y Restauración Cuatitlan Izcalli" />
    <meta property="og:type" content="video-movie" />
    <meta property="og:url" content="http://arqfranciscoga-002-site5.btempurl.com/PreRegistro"" />
    <meta property="og:image" content="Comun/favicon/Aplicacion.ico"" />

    <link href="Comun/LibreriasIconos/fontello/css/fontello.css" rel="stylesheet" />
    <link href="Comun/LibreriasIconos/fontello/css/animation.css" rel="stylesheet" />
    <link href="Content/Site.css" rel="stylesheet" />

</head>
<body>
    <form id="formularion" runat="server">
        <div id=""  class="Encabezado"> 
            <!-- <img src="Comun/img/encabezado.png" alt="Evento"> -->
        </div>
        <div id=""  class="Captura"> 
             <h1>   R  E  G  I  S  T  R  O </h1>
             <br />
             <asp:Label runat="server" Text="Nombre" CssClass="Etiqueta Gde" ></asp:Label>
             <asp:TextBox runat="server"  ID="txtNombre" CssClass="CajaTexto BordeIzq ColorTema" Width="250px"></asp:TextBox>
             <asp:RequiredFieldValidator id="RequiredFieldValidator2"
             ControlToValidate="txtNombre"
             Text="Ingrese el nombre por favor"
             EnableClientScript="true"
             CssClass="Validador"
             runat="server"/>
             <br />
             <asp:Label runat="server" Text="Edad" CssClass="Etiqueta Gde" ></asp:Label>
             <asp:TextBox runat="server"  ID="txtEdad" CssClass="CajaTexto BordeIzq ColorTema" Width="250px"></asp:TextBox>
             <asp:RangeValidator id="Range1"
             ControlToValidate="txtEdad"
             MinimumValue="10"
             MaximumValue="100"
             Type="Integer"
             EnableClientScript="true"
             Text="La edad debe ser entre 10y 100"
             CssClass="Validador"
             runat="server"/>

             <asp:RequiredFieldValidator id="RequiredFieldValidator1"
             ControlToValidate="txtEdad"
             Text="Ingrese la edad  por favor"
             EnableClientScript="true"
             CssClass="Validador"
             runat="server"/>
             <br />
             <asp:Label runat="server" Text="Genero" CssClass="Etiqueta Gde" ></asp:Label>
             <asp:DropDownList  ID="rblGenero"   runat="server"  CssClass="ListaOpciones BordeIzq" Width="250px">
                <asp:ListItem Text="Mujer" Value ="M" >Mujer</asp:ListItem>
                <asp:ListItem Text="Hombre" Value ="H" >Hombre</asp:ListItem>
             </asp:DropDownList>
             <br />
             <asp:Label runat="server"  ID="lblTelefono" Text=" Teléfono " CssClass="Etiqueta Gde"></asp:Label>
             <asp:TextBox runat="server"  ID="txtTelefono" CssClass="CajaTexto BordeIzq  ColorTema" Width="250px"></asp:TextBox>
             <br />
             <asp:Label runat="server"  ID="lblCorreo"  Text=" Correo" CssClass="Etiqueta Gde"></asp:Label>
             <asp:TextBox runat="server"  ID="txtCorreo" CssClass="CajaTexto BordeIzq  ColorTema" Width="250px"></asp:TextBox>
             <br />
             <asp:Label runat="server" Text=" Nombre de la persona que realizo la invitacion" CssClass="Etiqueta Gde"></asp:Label>
             <asp:TextBox runat="server"  ID="txtInvitador" CssClass="CajaTexto BordeIzq  ColorTema" Width="250px"></asp:TextBox>
             <br />
             <asp:Label runat="server" Text="Padece alguna enferemedad?. indíquela " CssClass="Etiqueta Gde" ></asp:Label>
             <asp:TextBox runat="server"  ID="txtEnfermedad" CssClass="CajaTexto BordeIzq ColorTema" Width="250px"></asp:TextBox>
             <br /> 
             <asp:Label runat="server" Text="¿Ha usted asistido a un retiro espiritual?" CssClass="Etiqueta Gde"></asp:Label>
             <asp:CheckBox ID="cvRetiro" runat="server" CssClass="CajaVerificacion BordeIzq ColorTema" Width="250px" />
             <br />
             <asp:Label runat="server" ID="lblEstadoCivil" Text="Estado civil" CssClass="Etiqueta Gde"></asp:Label>
             <asp:DropDownList  ID="rblEstadoCivil"   runat="server" CssClass="ListaOpciones BordeIzq" Width="250px">
                <asp:ListItem Text="Soltero(a)" Value ="S" >Soltero(a)</asp:ListItem>
                <asp:ListItem Text="Union libre" Value ="U">Union libre</asp:ListItem>
                <asp:ListItem Text="Casado(a)" Value ="C" >Casado(a)  </asp:ListItem>
                <asp:ListItem Text="Separado(a)" Value ="S">Separado(a)</asp:ListItem>
                <asp:ListItem Text="Madre Soltera" Value ="M">Madre Soltera</asp:ListItem>
                <asp:ListItem Text="Divorciado(a)" Value ="D" >Divorciado(a)</asp:ListItem>
                <asp:ListItem Text="Viudo(a)" Value ="V" >Viudo(a)</asp:ListItem>
 
             </asp:DropDownList>
             <br />
             <asp:Label runat="server" ID="lblReligion"  Text="Practica alguna religion?. indíquela " CssClass="Etiqueta Gde" ></asp:Label>
             <asp:TextBox runat="server"    ID="txtReligion"  CssClass="CajaTexto BordeIzq ColorTema" Width="250px"> </asp:TextBox>
             <br />
             <asp:Label runat="server" ID="lblCongregacion"  Text="Nombre de la congregacion a la que asiste" CssClass="Etiqueta Gde"></asp:Label>
             <asp:TextBox runat="server"   ID="txtCongregacion" CssClass="CajaTexto BordeIzq ColorTema" Width="250px"></asp:TextBox>
             <br />
              <asp:Label runat="server" ID="lblEstatus"  Text="Estatus" CssClass="Etiqueta Gde"></asp:Label>
              <asp:CheckBox ID="cvEstatus" runat="server" CssClass="CajaVerificacion BordeIzq ColorTema" Width="250px" />
              <br />
             <asp:Label runat="server" Text="" CssClass="Etiqueta Gde"></asp:Label>
<%--              <a href="/PreRegistros">Regresar</a>--%>
             <asp:Button ID="btnRegresar" runat="server" Text="Regresar"  CssClass="Boton BordeAbajo Ch ColorTema "   OnClick="btnRegresar_Click"  />
             <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar"  CssClass="Boton BordeAbajo Ch ColorTema " OnClick="btnLimpiar_Click"    />
             <asp:Button ID="btnRegistrar" runat="server" Text="Registrar"  CssClass="Boton BordeAbajo Ch ColorTema "   OnClick="btnRegistrar_Click" />
             <br />     
             <br />  
             <asp:Label runat="server" Text="" CssClass="Etiqueta Gde"></asp:Label>
             <asp:Label runat="server"  ID="lblOperacion" Text="" CssClass="Mensaje Gde"></asp:Label>
          </div>
     

           <div id=""  class="Pie">   
               <div style="top: 100% ; left:1% ;  position: absolute;" >
                    <br />  
                    <h1>   D I R E C I Ó N </h1>
                    <br />  
                     <div class="Subtitulo" > Salón Quinta los Girasoles</div>
                     <div class="Subtitulo"> Calle: Josefa Ortiz de Domínguez s/n. Col. Ricardo Flores Magón. </div>
                     <div class="Subtitulo"> Tepotzotlán. Estado de México. C.p. 54607</div>
                    <p></p>
                    <br />  
                    <h1>   U B I C A C I Ó N </h1>
                    <br />  
    <%--            <a href='https://maps-generator.com/'>Maps Generator</a>--%>
                    <iframe width="500" height="400" frameborder="0" scrolling="no" marginheight="0" marginwidth="0" id="gmap_canvas" src="https://maps.google.com/maps?width=500&amp;height=400&amp;hl=en&amp;q=Calle%20Josefa%20Ortiz%20de%20Dom%C3%ADnguez%20s/n%20%20Col.%20Ricardo%20Flores%20Mag%C3%B3n%20CP.%2054607%20Tepotzotl%C3%A1n%20%20,Estado%20de%20M%C3%A9xico+(Sal%C3%B3n%20Quinta%20los%20Girasoles)&amp;t=&amp;z=12&amp;ie=UTF8&amp;iwloc=B&amp;output=embed"></iframe>
                </div>
            </div>

           <footer class="FinalPagina"> 
                <div class="PiePaginaSocial">
                  
                    <a class="icon-facebook-rect" href="https://www.facebook.com/Amoryrestauracioncuatitlanizcalli" > </a>
                    <a  class="icon-youtube" href="https://www.youtube.com" >   </a>
                </div>
                <div class="PiePaginaDerechos" > 
                    <p></p>
                      &copy; STI - Todos los derechos reservados - 2022
                    <p></p>
                </div>
                <p></p>

           </footer>
    </form>
</body>
</html>
