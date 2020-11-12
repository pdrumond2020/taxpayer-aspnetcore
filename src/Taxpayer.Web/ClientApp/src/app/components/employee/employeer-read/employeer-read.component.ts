import { Employee } from './../employee.modal';
import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../employee.service';

@Component({
  selector: 'app-employeer-read',
  templateUrl: './employeer-read.component.html',
  styleUrls: ['./employeer-read.component.css']
})
export class EmployeerReadComponent implements OnInit {

  employee: Employee[]
  displayedColumns = ['identificationNumber', 'name', 'grossSalary', 'numberOfDependants']

  constructor(private employeeService: EmployeeService) { }

  ngOnInit(): void {
    this.employeeService.read().subscribe(employee => {
      console.log(employee.data)
      this.employee = employee.data
    })
  }

}
