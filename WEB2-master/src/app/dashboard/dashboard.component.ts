import { Component, OnInit, Input } from '@angular/core';
import { EmployeeService } from '../employee services/employee.service';
import { Employee } from '../employee services/employee.service';
import { DepartmentService } from '../services/department.service';
import { Department } from '../services/department.service';
import { TasksService } from './../services/tasks.service';
import { Task } from '../services/tasks.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  constructor(private tasksService: TasksService,
		private employeeService: EmployeeService,
    private departmentService: DepartmentService) { }
    
    public tasks: Array<Task>;
    public employees: Array<Employee>;
    public departments: Array<Department>;
    public selectedEmployee;
    public selectedTask;
    public selectedDepartment;
    public foundEmployee;
    public foundDepartment;
    public Dep : Department;
  @Input() Employee: Employee;

  ngOnInit() {
    this.getTasks();
		this.getEmployees();
		this.getDepartments();
  }
	private getTasks() {
		this.tasksService.getTasks().subscribe((tasks) => (this.tasks = tasks));
	}

	private getEmployees() {
		this.employeeService.getEmployees().subscribe((employees) => (this.employees = employees));
	}
 
	private getDepartments() {
		this.departmentService.getDepartments().subscribe((departments) => (this.departments = departments));
  }
  
  onSelectEmp(employee: Employee): void {
		this.selectedEmployee = employee;
    }
  
  onSelectTask(task: Task): void {
    this.selectedTask = task;
    }
  
  onSelectDep(department: Department): void {
    this.selectedDepartment = department;
    }

  public getName(id:number): String{
    this.departmentService.getdepartment(id).subscribe((dep)=>{this.Dep=dep});
		return this.Dep.name;
    
     }
  public searchEmployee(name:string){
    let emp=this.employeeService.getEmployee(name);
    this.foundEmployee=emp;
    let dep=this.departmentService.getDepartment(name);
    this.foundDepartment=dep;
  }
}
