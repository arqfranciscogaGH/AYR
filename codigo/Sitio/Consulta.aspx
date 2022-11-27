<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Consulta.aspx.cs" Inherits="Sitio.Consulta" %>


<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" lang="es">
<head runat="server">
    <title>Consulta </title>
    <meta charset="utf-8"/>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge">

    <meta name="keywords" content="Amor y Restauración Cuatitlan Izcalli " />
    <meta name="description" content="Amor y Restauración Cuatitlan Izcalli">
    <meta name="viewport"  content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1"/>

    <meta name="msapplication-tap-highlight" content="no" />
    <meta name="robots" content="index,follow,all" />
    <meta name="author" content="Francisco Garcia | STI" />

    <link rel="shortcut icon" href="Comun/favicon/Aplicacion.ico" type="image/x-icon">
    <link rel="icon" href="Comun/favicon/Aplicacion.ico" type="image/x-icon">

    <meta property="og:title" content="Amor y Restauración Cuatitlan Izcalli" />
    <meta property="og:type" content="video-movie" />
    <meta property="og:url" content="http://arqfranciscoga-002-site5.btempurl.com/PreRegistro"" />
    <meta property="og:image" content="Comun/favicon/Aplicacion.ico"" />

    <!-- Bootstrap-->
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/css/bootstrap.min.css" integrity="sha384-Zenh87qX5JnK2Jl0vWa8Ck2rdkQ2Bzep5IDxbcnCeuOxjzrPF/et3URy9Bv1WTRi" crossorigin="anonymous" />
    <!-- DataTable -->
    <link rel="stylesheet" href="https://cdn.datatables.net/1.12.1/css/dataTables.bootstrap5.min.css" />
    <!-- Font Awesome -->
    <link
        rel="stylesheet"
        href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.2.0/css/all.min.css"
        integrity="sha512-xh6O/CkQoPOWDdYTDqeRdPCVd1SpvCA9XXcUnZS2FmJNp1coAFzvtCN9BmamE+4aHK8yyUHUSCcJHgXloTyT2A=="
        crossorigin="anonymous"
        referrerpolicy="no-referrer"
    />
    <!-- Custom CSS -->
    <link rel="stylesheet" href="styles.css" />

<%--  
    <link href="Comun/LibreriasIconos/fontello/css/fontello.css" rel="stylesheet" />
    <link href="Comun/LibreriasIconos/fontello/css/animation.css" rel="stylesheet" />
    <link href="Content/Site.css" rel="stylesheet" />
    <script src="Comun/Js/Sitiot.js"></script>
    
--%>

</head>
<body>
    <form id="form1" runat="server">
        <h1> Registro Retiro de Transformación </h1>
        <div class="container my-4">
            <div class="row">
                <div class="col-sm-12 col-md-12 col-lg-12 col-xl-12">
                    <table id="datatable_consulta" class="table table-striped">
                        <caption>
                           Personas registrados 
                        </caption>
                        <thead>
                            <tr>
                                <th class="centered">Id</th>
                                <th class="centered">Nombre</th>
                                <th class="centered">Género</th>
                                <th class="centered">Edad</th>
                                <th class="centered">Estado Civil</th>
                                <th class="centered">Teléfono</th>
<%--    
                                <th class="centered">Enfermedad</th>
                                <th class="centered">Teléfono</th>
                                <th class="centered">Correo</th>
                                <th class="centered">Religión</th>
                                <th class="centered">Cóngregación</th>
                                <th class="centered">Asistió a retiro</th>
                                <th class="centered">Estatus</th>--%>
                            </tr>
                        </thead>
                        <tbody id="tablaElementos"></tbody>
                    </table>
                </div>
            </div>
        </div>
        <!-- Bootstrap-->
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-OERcA2EqjJCMA+/3y+gxIOqMEjwtxJY7qPCqsdltbNJuaOe923+mo//f6V8Qbsw3" crossorigin="anonymous"></script>
        <!-- jQuery -->
        <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
        <!-- DataTable -->
        <script src="https://cdn.datatables.net/1.12.1/js/jquery.dataTables.min.js"></script>
        <script src="https://cdn.datatables.net/1.12.1/js/dataTables.bootstrap5.min.js"></script>
        <!-- Custom JS -->
        <script src="Comun/Js/Sitiot.js"></script>
    </form>
</body>
</html>
