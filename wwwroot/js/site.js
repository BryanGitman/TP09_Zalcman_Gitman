﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function HorizontalOVertical(id)
{
    var image = $("#"+id);
    if(image.width() > image.height())
    {
        image.attr('class',"imgH")
    }
}

function SesionIniciadaONo()
{
    $.ajax(
        {
            type: 'POST',
            dataType: 'JSON',
            url: '/Home/VerComentariosAjax',
            success:
            function (response)
            {
                $("#comentariostitulo").html("Comentarios (" + response.Count + ")");
                $("#comentarioscontenido").html("@{foreach(Temporadas temporada in " + response + "){<p>Temporada @temporada.NumeroTemporada - @temporada.TituloTemporada</p>}}");
            }
        }
    );
}

function MostrarComentarios(IdP)
{
    $.ajax(
        {
            type: 'POST',
            dataType: 'JSON',
            url: '/Home/VerComentariosAjax',
            data: { IdPost: IdP },
            success:
                function (response)
                {
                    $("#comentariostitulo").html("Comentarios (" + response.Count + ")");
                    $("#comentarioscontenido").html("@{foreach(Temporadas temporada in " + response + "){<p>Temporada @temporada.NumeroTemporada - @temporada.TituloTemporada</p>}}");
                },
            error:
                function (response)
                {
                    $("#comentariostitulo").html("Comentarios (" + response.Count + ")");
                    $("#comentariostitulo").html("No se encontraron comentarios en esta publicación");
                }
        }
    );
}
