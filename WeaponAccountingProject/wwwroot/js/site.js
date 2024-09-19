// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
// Write your JavaScript code.

//$(".btnOpenWeaponInfoModal").on('click', function () {
//    $('#showWeaponModal').modal('show');
//});

//const myModal = new bootstrap.Modal('#showWeaponModal');

document.querySelectorAll('.btnOpenWeaponInfoModal').forEach(function (button) {
    button.addEventListener('click', function () {
        var row = this.closest('tr'); // Get the closest <tr> of the clicked button

        var RecordNumber = row.querySelector('td:first-child div:nth-child(1)').textContent;
        var name = row.querySelector('td:first-child div:nth-child(2)').textContent;
        //var amount = row.querySelector('.transaction-amount div').textContent;
        var year = row.querySelector('td:first-child div:nth-child(3)').textContent;
        var locationCell = row.querySelector('td.weapon-location');
        var locationName;
        if (locationCell.querySelector('span')) {
            locationName = locationCell.querySelector('span').textContent; // Get fallback "No Location Available"
        } else {
            locationName = locationCell.textContent.trim(); // Get the location name
        }
        //var categoryId = row.querySelector('td:nth-child(5)').textContent;
        //var transactionType = row.querySelector('#transaction-type').textContent;

        ////// Now you can use these variables as needed
        //console.log(id, date, amount, name, categoryId, transactionType);
        document.getElementById('modalWeaponRecordNumber').textContent = RecordNumber; 
        document.getElementById('modalWeaponName').textContent = name;
        document.getElementById('modalWeaponYear').textContent = year;
        document.getElementById('modalWeaponLocationName').textContent = locationName;

        var modal = new bootstrap.Modal(document.getElementById('showWeaponModal'));
        modal.show();
    });
});

//btnOpenWeaponInfoModal.AddEventListener('click', () => {
//    myModal.show();
//});