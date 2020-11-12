import { Component, OnInit } from '@angular/core';
import { Employee } from '../../employee/employee.modal';
import { EmployeeService } from '../../employee/employee.service';

@Component({
  selector: 'app-calculate-ir',
  templateUrl: './calculate-ir.component.html',
  styleUrls: ['./calculate-ir.component.css']
})
export class CalculateIrComponent implements OnInit {

  employee: Employee[]
  displayedColumns = ['identificationNumber', 'name', 'grossSalary', 'numberOfDependants', 'valueTaxIR']
  minimumWage: any;

  constructor(private employeeService: EmployeeService) { }

  ngOnInit(): void {
  }

  calculateValueTax(): void {
    this.employeeService.calculate(this.minimumWage).subscribe(employee => {
      console.log(employee.data)
      this.employee = employee.data
    })
  }

}
