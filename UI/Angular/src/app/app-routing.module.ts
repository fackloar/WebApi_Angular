import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AboutComponent } from './about/about.component';

import {EmployeeComponent} from './employee/employee.component';
const routes: Routes = [
  {path:'employees', component:EmployeeComponent},
  {path: '', component:AboutComponent, pathMatch: "full"}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
