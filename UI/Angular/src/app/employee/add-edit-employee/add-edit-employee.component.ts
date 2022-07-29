import { Component, Input, OnInit } from '@angular/core';
import { Employee } from 'src/app/models/employee.model';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-add-edit-employee',
  templateUrl: './add-edit-employee.component.html',
  styleUrls: ['./add-edit-employee.component.css']
})
export class AddEditEmployeeComponent implements OnInit {

  constructor(private service:SharedService) { }

  @Input() employee!: Employee;
  EmployeeID: any;
  EmployeeDepartment!: string;
  EmployeeName!: string;
  DateOfBirth!: string;
  DateOfJoining!: string;
  EmployeeSalary!: string;

  ngOnInit(): void {
    this.EmployeeID=this.employee.EmployeeID;
    this.EmployeeDepartment=this.employee.EmployeeDepartment;
    this.EmployeeName=this.employee.EmployeeName;
    this.DateOfBirth=this.employee.DateOfBirth;
    this.DateOfJoining=this.employee.DateOfJoining;
    this.EmployeeSalary=this.employee.EmployeeSalary;

  }

  addEmployee(){
    var value = {
                EmployeeID:this.EmployeeID,
                EmployeeDepartment:this.EmployeeDepartment,
                EmployeeName:this.EmployeeName,
                DateOfBirth:this.DateOfBirth,
                DateOfJoining:this.DateOfJoining,
                EmployeeSalary:this.EmployeeSalary
                };
    this.service.addEmployee(value).subscribe(response => {
      alert("Сотрудник добавлен");
    });
  }

  updateEmployee(){
    var value = {
                EmployeeID:this.EmployeeID,
                EmployeeDepartment:this.EmployeeDepartment,
                EmployeeName:this.EmployeeName,
                DateOfBirth:this.DateOfBirth,
                DateOfJoining:this.DateOfJoining,
                EmployeeSalary:this.EmployeeSalary
                };
    this.service.updateEmployee(value).subscribe(response => {
      alert("Изменения сохранены");
    })

  }
}
