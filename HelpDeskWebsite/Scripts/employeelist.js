$(function () { // employeelist.js 
    let getAll = async (msg) => {
        try {
            $('#status').text('Finding Employee Information...');
            let response = await fetch(`api/employees/`);
            if (!response.ok) // or check for response.status
                throw new Error(`Status - ${response.status}, Text - ${response.statusText}`);
            let data = await response.json(); // this returns a promise, so we await it 
            buildEmployeeList(data);
            (msg === '') ? // are we appending to an existing message
                $('#status').text('Employees Loaded') : $('#status').text(`${msg} - Employees Loaded`);
        } catch (error) {
            $('#status').text(error.message);
        }
    } // getAll

    let clearModalFields = () => {
        $('#TextBoxTitle').val('');
        $('#TextBoxFirstname').val('');
        $('#TextBoxLastname').val('');
        $('#TextBoxPhone').val('');
        $('#TextBoxEmail').val('');
        localStorage.removeItem('Id');
        localStorage.removeItem('DepartmentId');
        localStorage.removeItem('Timer');
    } // Clear ModalFields

    $('#employeeList').click((e) => {
        if (!e) e = window.event;
        let Id = e.target.parentNode.id;
        if (Id === 'employeeList' || Id === '') {
            Id = e.target.id;
        } // clicked on row somewhere else
        if (Id !== 'status' && Id !== 'heading') {
            let data = JSON.parse(localStorage.getItem('allemployees'));
            clearModalFields();
            data.map(employee => {
                if (employee.Id === parseInt(Id)) {
                    $('#TextBoxTitle').val(employee.Title);
                    $('#TextBoxFirstname').val(employee.Firstname);
                    $('#TextBoxLastname').val(employee.Lastname);
                    $('#TextBoxPhone').val(employee.Phoneno);
                    $('#TextBoxEmail').val(employee.Email);
                    localStorage.setItem('Id', employee.Id);
                    localStorage.setItem('DepartmentId', employee.DepartmentId);
                    localStorage.setItem('Timer', employee.Timer);
                    $('#modalstatus').text('update data');
                    $('#theModal').modal('toggle');
                } // if
            }); // data.map
        } else {
            return false; // ignore if they clicked on heading or status
        }
    }); // EmployeeListClick

    $('#updatebutton').click(async (e) => { // Update Employee button click event handler
        try {
            emp = new Object();
            emp.Title = $('#TextBoxTitle').val();
            emp.Firstname = $('#TextBoxFirstname').val();
            emp.Lastname = $('#TextBoxLastname').val();
            emp.Phoneno = $('#TextBoxPhone').val();
            emp.Email = $('#TextBoxEmail').val();
            emp.Id = localStorage.getItem('Id');
            emp.DepartmentId = localStorage.getItem('DepartmentId');
            emp.Timer = localStorage.getItem('Timer');
            // send the updated back to the server asynchronously using PUT
            let response = await fetch('api/employees', {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json; charset=utf-8'
                },
                body: JSON.stringify(emp)
            });
            if (response.ok) // or check for response.status
            {
                let data = await response.json();
                $('#status').text(data);
            } else {
                $('#status').text(`${response.status}, Text - ${response.statusText}`);
            } // else
            $('#theModal').modal('toggle');
        } catch (error) {
            $('#status').text(error.message);
        } // try/catch

    }); // updatebutton click

    let buildEmployeeList = (data) => {
        $('#employeeList').empty();
        div = $(`<div class="list-group-item text-white bg-secondary row d-flex" id="status">Employee Info</div> 
            <div class= "list-group-item row d-flex text-center" id="heading">
            <div class="col-4 h4">Title</div> 
            <div class="col-4 h4">First</div> 
            <div class="col-4 h4">Last</div>
           </div>`);

        div.appendTo($('#employeeList'))
        localStorage.setItem('allemployees', JSON.stringify(data));
        data.map(emp => {
            btn = $(`<button class="list-group-item row d-flex" id="${emp.Id}">`);
            btn.html(`<div class="col-4" id="employeetitle${emp.Id}">${emp.Title}</div>
                    <div class="col-4" id="employeefname${emp.Id}">${emp.Firstname}</div>
                    <div class="col-4" id="employeelastname${emp.Id}">${emp.Lastname}</div>`
            );
            btn.appendTo($('#employeeList'));
        }); // map
    } // buildEmployeeList

    getAll(''); // first grab the data from the server
});