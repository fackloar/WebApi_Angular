import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse, HttpResponseBase } from '@angular/common/http';
import { map, Observable } from 'rxjs/';
import { Employee } from './models/employee.model';

@Injectable({
  providedIn: 'root'
})
export class SharedService {
readonly APIUrl="https://localhost:7137/api/Employee";

  constructor(private http:HttpClient) { }

  getEmployeeList(): Observable<Employee[]>{
    return this.http.get<Employee[]>(this.APIUrl);
  }

  addEmployee(employee: Employee): Observable<Employee>{
    return this.http.post<Employee>(this.APIUrl, employee);
  }

  updateEmployee(employee: Employee): Observable<Employee>{
    return this.http.put<Employee>(this.APIUrl+"/id/" + employee.EmployeeID, employee);
  }

  deleteEmployee(employee: Employee): Observable<Employee>{
    return this.http.delete<Employee>(this.APIUrl+"/id/"+ employee.EmployeeID);
  }
}
