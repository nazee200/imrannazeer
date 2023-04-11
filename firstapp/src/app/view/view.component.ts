import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { EmployeeCombine } from '../Model/employee.model';
import { EmployeeService } from '../Service/employee.service';

@Component({
  selector: 'app-view',
  templateUrl: './view.component.html',
  styleUrls: ['./view.component.css']
})
export class ViewComponent implements OnInit {
  employeearr:EmployeeCombine[]=[];
  constructor(private empservice:EmployeeService,private route:Router) { }


  ngOnInit() {
    this.empservice.getEmployee().subscribe(responseData=>{
      for(const key in responseData){
        this.employeearr.push(responseData[key]);
      } 
      
    });

   
  }

  onDelete(emp:EmployeeCombine){
    this.empservice.tempId=emp.id;
    this.empservice.deleteEmployee().subscribe();
    this.empservice.tempId=0;
    

  }
  fillform(emp:EmployeeCombine){
    this.empservice.tempEmployee=emp;
    this.empservice.tempId=emp.id;
    this.route.navigate(['/']);
    
  }

}
