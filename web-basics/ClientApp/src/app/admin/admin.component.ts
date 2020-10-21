import { Component, OnInit } from '@angular/core';
import { AdminService } from './admin.service';
import { IAccount, Role } from './account';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {

  constructor(private adminService: AdminService) { }

  accounts: IAccount[];
  roles: string[] = ['User', 'Admin'];
  email: string;
  password: string;
  changeRole: string;
  role: string;

  ngOnInit() {
    this.adminService.get().subscribe(data => {
      this.accounts = data;
    });
  }

  onDelete(id: number) {
    this.adminService.delete(id).subscribe(() => {
      this.accounts = this.accounts.filter(acc => acc.id !== id);
    });
  }

  isAdminAccount(account: IAccount): boolean {
    return (account.role == Role.Admin);
  }

  onEditingRole(id: number) {
    this.accounts.map(item => { item.id === id ? item.isEditingRole = true : null });
  }

  cancelEditingRole(id: number) {
    this.accounts.map(item => { item.id === id ? item.isEditingRole = false : null });
  }

  onSubmit() {
    if (this.role === "") return;
    this.adminService.create(this.email, this.password, this.roles.indexOf(this.role)).subscribe(account => {
      this.accounts.push(account);
    });
  }

  onChangeRole(id: number) {
    if (this.changeRole === "") return;
    this.adminService.changeRole(id, this.roles.indexOf(this.changeRole)).subscribe(changedAcc => {
      this.accounts.forEach(acc => acc.id === changedAcc.id ? acc.role = changedAcc.role : null);
    });
    this.cancelEditingRole(id);
  }
}
