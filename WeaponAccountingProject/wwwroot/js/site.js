// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
// Write your JavaScript code.

document.querySelectorAll('.btnOpenWeaponInfoModal').forEach(function (button) {
    button.addEventListener('click', function () {
        var row = this.closest('tr'); // Get the closest <tr> of the clicked button

        var recordNumber = row.querySelector('td:first-child div:nth-child(1)').textContent;
        var name = row.querySelector('td:first-child div:nth-child(2)').textContent;
        var year = row.querySelector('td:first-child div:nth-child(3)').textContent;
        var value = row.querySelector('td:first-child div:nth-child(4)').textContent;
        var locationCell = row.querySelector('td.weapon-location');
        var locationName;
        if (locationCell.querySelector('span')) {
            locationName = locationCell.querySelector('span').textContent; // Get fallback "No Location Available"
        } else {
            locationName = locationCell.textContent.trim(); // Get the location name
        }

        console.log(recordNumber, name, year, value, locationName);

        document.getElementById('modalWeaponRecordNumber').textContent = recordNumber; 
        document.getElementById('modalWeaponName').textContent = name;
        document.getElementById('modalWeaponYear').textContent = year + 'рік';
        document.getElementById('modalWeaponValue').textContent = value;
        document.getElementById('modalWeaponLocationName').textContent = locationName;

        var modal = new bootstrap.Modal(document.getElementById('showWeaponModal'));
        modal.show();
    });
});

