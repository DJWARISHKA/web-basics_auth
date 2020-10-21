export interface IAccount {

  id: number;
  email: string;
  password: string;
  role: Role;
  isEditingRole: boolean;
}

export enum Role {
  User,
  Admin
}
