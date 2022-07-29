import { Component, OnInit } from '@angular/core';
import { Employee } from 'src/app/models/employee.model';
import { SharedService } from 'src/app/shared.service';
import { compileDeclareClassMetadata } from '@angular/compiler';

@Component({
  selector: 'app-show-employee',
  templateUrl: './show-employee.component.html',
  styleUrls: ['./show-employee.component.css']
})
export class ShowEmployeeComponent implements OnInit {
  employees: Employee[] = [];
  sortedEmployees: Employee[] = [];

  ModalTitle!: string;
  ActivateAddEditEmployeeComponent: boolean = false;
  employee!: Employee;
  display = "none";

  EmployeeDepartmentFilter: string = "";
  EmployeeNameFilter: string = "";
  EmployeeSalaryFilter: string = "";
  DateOfBirthFilter: string = "";
  DateOfJoiningFilter: string = "";
  EmployeeListWithoutFilter: Employee[] = [];

  constructor(private service : SharedService) { }

  ngOnInit(): void {
    this.getEmployees();
  }

  openModal() {
    this.display = "block";
  }
  onCloseHandled() {
    this.display = "none";
  }

  addClick(){
    this.employee = {
      EmployeeID:"0",
      EmployeeDepartment:"",
      EmployeeName:"",
      DateOfBirth:"",
      DateOfJoining:"",
      EmployeeSalary:""
    }
    this.ModalTitle = "Add Employee";
    this.ActivateAddEditEmployeeComponent = true;
  }

  editClick(employee: Employee){
    this.employee=employee;
    this.ModalTitle="Edit Employee";
    this.ActivateAddEditEmployeeComponent = true;
  }

  deleteClick(employee: Employee){
    if(confirm("Удалить сотрудника?")){
      this.service.deleteEmployee(employee).subscribe(response =>
        {
          alert("Сотрудник удалён");
          this.getEmployees();
        })
    }
  }

  closeClick(){
    this.ActivateAddEditEmployeeComponent = false;
    this.getEmployees();
  }

  getEmployees() {
    this.service.getEmployeeList()
    .subscribe(
      response => {
        this.employees = response;
        this.EmployeeListWithoutFilter = response;
      }
    );
  }

  FilterFunction(){
    var EmployeeDepartmentFilter = this.EmployeeDepartmentFilter;
    var EmployeeNameFilter = this.EmployeeNameFilter;
    var EmployeeSalaryFilter = this.EmployeeSalaryFilter;


    this.employees = this.EmployeeListWithoutFilter.filter(function (el){
      return el.EmployeeDepartment.toString().toLowerCase().includes(
        EmployeeDepartmentFilter.toString().trim().toLowerCase()
      )&&
      el.EmployeeName.toString().toLowerCase().includes(
        EmployeeNameFilter.toString().trim().toLowerCase()
      )&&
      el.EmployeeSalary.toString().toLowerCase().includes(
        EmployeeSalaryFilter.toString().trim().toLowerCase()
      )
    });
  }

  DateOfBirthFilterFunction(){
    var DateOfBirthFilter = this.DateOfBirthFilter;
  
    var parsedDateOfBirthFilterParts = DateOfBirthFilter.split('-');
    var parsedDateOfBirthFilter = parsedDateOfBirthFilterParts[2]?.concat(".", parsedDateOfBirthFilterParts[1], ".", parsedDateOfBirthFilterParts[0]);

    this.employees = this.EmployeeListWithoutFilter.filter(function (el){
      return el.DateOfBirth.includes(
        parsedDateOfBirthFilter)
    });

  }

  DateOfJoiningFilterFunction(){
    var DateOfJoiningFilter = this.DateOfJoiningFilter;

    var parsedDateOfJoiningFilterParts = DateOfJoiningFilter.split('-');
    var parsedDateOfJoiningFilter = parsedDateOfJoiningFilterParts[2]?.concat(".", parsedDateOfJoiningFilterParts[1], ".", parsedDateOfJoiningFilterParts[0]);

    this.employees = this.EmployeeListWithoutFilter.filter(function (el){
      return el.DateOfJoining.includes(
        parsedDateOfJoiningFilter)
  });
}


  sortResult(prop: string,asc: any){
    this.employees = this.EmployeeListWithoutFilter.sort(function(a,b){
      if(prop == "DateOfBirth" || prop == "DateOfJoining"){
        var partsA = a[prop].split(".");
        var partsB = b[prop].split(".");
        var dateA = new Date(parseInt(partsA[2], 10),
                            parseInt(partsA[1], 10) - 1,
                            parseInt(partsA[0], 10));
        var dateB = new Date(parseInt(partsB[2], 10),
                            parseInt(partsB[1], 10) - 1,
                            parseInt(partsB[0], 10));

        if(asc){
          return (dateA > dateB)?1 : ((dateA<dateB) ?-1 :0)
        }
        else{
          return (dateB > dateA)?1 : ((dateB<dateA) ?-1 :0)
        }
      }
      if(asc){
        return (a[prop as keyof Employee]>b[prop as keyof Employee])?1 : ((a[prop as keyof Employee]<b[prop as keyof Employee]) ?-1 :0)
      }
      else{
        return (b[prop as keyof Employee]>a[prop as keyof Employee])?1 : ((b[prop as keyof Employee]<a[prop as keyof Employee]) ?-1 :0)
      }
    })
  }
}