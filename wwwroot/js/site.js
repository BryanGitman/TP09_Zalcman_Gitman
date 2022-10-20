// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
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
