import { CalculateComponent } from './views/calculate/calculate.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './views/home/home.component';
import { EmployeeComponent } from './views/employee/employee.component';
import { EmployeerCreateComponent } from './components/employee/employeer-create/employeer-create.component';

const routes: Routes = [
    {
      path: '',
      component: HomeComponent
    },
    {
      path: 'employees',
      component: EmployeeComponent
    },
    {
      path: 'employee/create',
      component: EmployeerCreateComponent
    },
    {
      path: 'calculate',
      component: CalculateComponent
    }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
  })
export class AppRoutingModule { }
