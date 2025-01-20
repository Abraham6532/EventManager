var tabla = document.getElementById("tablaEventos");
var titulo = document.getElementById("titulo");
var formulario = document.getElementById("formulario");
tabla.hidden = true;

function MostrarFormulario() {
    tabla.hidden = true;
    formulario.hidden = false;
    titulo.textContent = "Agregar evento";
}


async function PostEventos() {
    try {
        // Obtener los valores de los campos
        const titulo = document.getElementById("tituloform").value;
        const descripcion = document.getElementById("descripcion").value;
        const lugar = document.getElementById("lugar").value;
        const fecha = document.getElementById("fecha").value;
        const UsuarioId = document.getElementById("UsuarioId").value;

        console.log(titulo);
        console.log(descripcion);
        console.log(lugar);
        console.log(fecha);
        console.log(UsuarioId);

        if (!titulo || !descripcion || !lugar || !fecha || !UsuarioId) {
            console.error("Todos los campos son necesarios");
            return;
        }

        const myHeaders = new Headers();
        myHeaders.append("Content-Type", "application/json");

        const raw = JSON.stringify({
            "titulo": titulo,
            "descripcion": descripcion,
            "lugar": lugar,
            "fecha": fecha,
            "UsuarioId": UsuarioId
        });

        const requestOptions = {
            method: "POST",
            headers: myHeaders,
            body: raw,
            redirect: "follow"
        };

       
        const response = await fetch("http://localhost:60104/api/Evento/", requestOptions);

        
        if (!response.ok) {
            throw new Error(`HTTP error! Status: ${response.status}`);
        }

        const result = await response.json(); 
        console.log(result);
    } catch (error) {
        console.error("Error en la solicitud:", error);
    }
}



async function GetEventos() {
    tabla.hidden = false;
    formulario.hidden = true;
    titulo.textContent = "Lista eventos";
    try {
        const response = await fetch("http://localhost:60104/api/Evento");
        if (!response.ok) {
            throw new Error(`HTTP error! Status: ${response.status}`);
        }
        const data = await response.json();
        console.log(data);
        return data; // Retorna la data
    } catch (error) {
        console.error("Error fetching eventos:", error);
    }
}

async function MostrarInformacion() {
    const eventos = await GetEventos();
    console.log(eventos);
    const tabla = document.getElementById("tablaEventos");
    // Crear la fila <tr>
    const fila = document.createElement("tr");
    fila.classList.add("card__right");

    const trElements = document.querySelectorAll("tr"); // Selecciona todos los <tr> en la página

    trElements.forEach(tr => {
        if (tr.id !== "encabezado") {
            tr.remove();
        } 
    });

    eventos.forEach((dato) => {
        const fila = document.createElement("tr");
        fila.classList.add("card__right");
        const propiedades = [dato.IdEvento, dato.Titulo, dato.Descripcion, dato.Lugar, dato.Fecha, dato.UsuarioId];
        propiedades.forEach((propiedad) => {
            const celda = document.createElement("td");
            celda.classList.add("item");
            celda.textContent = propiedad;
            fila.appendChild(celda); 
        });
        tabla.appendChild(fila);
    });

    // Agregar la fila completa a la tabla
    tabla.appendChild(fila);
    

}