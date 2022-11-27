
let dataTable;
let dataTableIsInitialized = false;

const dataTableOptions = {
    //scrollX: "2000px",
    lengthMenu: [5,10, 15, 20,50, 100, 200],
    columnDefs: [
        { className: "centered", targets: [0, 1, 2, 3, 4, 5, 6] },
        { orderable: false, targets: [5, 6] },
        { searchable: false, targets: [2] }
        //{ width: "50%", targets: [0] }
    ],
    pageLength: 10,
    destroy: true,
    language: {
        lengthMenu: "Mostrar _MENU_ registros por página",
        zeroRecords: "No se encontró ningín registro en la búsqueda",
        info: "Encontró  _START_ a _END_ de _TOTAL_ ",
        infoEmpty: "No hay registros",
        infoFiltered: "( Total registros:  _MAX_ )",
        search: "Buscar:",
        loadingRecords: "Cargando...",
        paginate: {
            first: "Primero",
            last: "Último",
            next: "Siguiente",
            previous: "Anterior"
        }
    }
};

const initDataTable = async () => {
    if (dataTableIsInitialized) {
        dataTable.destroy();
    }

    await obtener();

    dataTable = $("#datatable_consulta").DataTable(dataTableOptions);

    dataTableIsInitialized = true;
};
const obtener = async () => {
    try {
        // http://arqfranciscoga-002-site5.btempurl.com/api/registros 
        // 
        const response = await fetch('http://localhost:55377/api/registros'
            ,{
                method: "GET",
                headers: { "Content-type": "application/json;charset=UTF-8" }
             }

        );
        const lista = await response.json();
        let content = ``;
        //                   <td>${index + 1}</td>
        //                 <td>${item.enfermedad}</td>

        //<td>${item.telefono}</td>
        //<td>${item.correo}</td>
        //<td>${item.religion}</td>
        //<td>${item.congregacion}</td>
        //<td>${item.retiroT}</td>
        //<td>${item.estatus}</td>

        lista.forEach((item, index) => {
            content += `
                <tr>
                    <td>${item.id}</td>
                    <td>${item.nombre}</td>
                    <td>${item.genero}</td>
                    <td>${item.edad}</td>
                    <td>${item.estadoCivil}</td>
                    <td>${item.telefono}</td>
                    <td>
                        <a href="/PreRegistro.aspx?id=${item.id}"  class="btn btn-sm btn-primary" > <i class="fa-solid fa-pencil"></i> Modificar </a>

                    </td>
                </tr>`;
        });
        //                         <a href="/PreRegistro.aspx?id=${item.id}"  class="btn btn-sm btn-danger" > <i class="fa-solid fa-trash-can"></i> Eliminar </a>
        //  <button class="btn btn-sm btn-danger"><i class="fa-solid fa-trash-can"></i></button>
        //  <button class="btn btn-sm btn-primary"> <i class="fa-solid fa-pencil"></i>  </button>

        tablaElementos.innerHTML = content;
    } catch (ex) {
        alert(ex);
    }
};

window.addEventListener("load", async () => {
    await initDataTable();
});


ejecutarUrl()
{

}


