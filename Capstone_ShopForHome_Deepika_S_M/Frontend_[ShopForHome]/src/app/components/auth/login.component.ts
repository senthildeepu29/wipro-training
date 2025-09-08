import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html'
})
export class LoginComponent {
  email = '';
  password = '';
  message = ''; // ✅ Add this property

  constructor(private authService: AuthService, private router: Router) {}

  login() {   // ✅ rename to match HTML
    this.authService.login({ email: this.email, password: this.password , }).subscribe({
      next: (user) => {
        if (user.role.toLowerCase() === 'admin') {
          this.router.navigate(['/admin/dashboard']);
        } else {
          this.router.navigate(['/products']);
        }

        this.message = '✅ Login successful!';
      },
      error: () => {
        this.message = '❌ Invalid email or password';
      }
    });
  }
}
// import { Component } from '@angular/core';
// import { Router } from '@angular/router';
// import { ToastrService } from 'ngx-toastr';
// import { AuthService } from '../../services/auth.service';

// @Component({
//   selector: 'app-login',
//   templateUrl: './login.component.html',
//   styleUrls: ['./login.component.css']
// })
// export class LoginComponent {
//   email: string = '';
//   password: string = '';

//   constructor(
//     private authService: AuthService,
//     private router: Router,
//     private toastr: ToastrService
//   ) {}

//  onSubmit() {
//   if (!this.email || !this.password) {
//     this.toastr.error('Please enter email and password');
//     return;
//   }

//   this.authService.login(this.email, this.password).subscribe({
//     next: (res: any) => {
//       this.toastr.success('Login successful!');
//       localStorage.setItem('token', res.token);
//       this.router.navigateByUrl('/');
//     },
//     error: () => {
//       this.toastr.error('Invalid email or password');
//     }
//   });
// }

// }
