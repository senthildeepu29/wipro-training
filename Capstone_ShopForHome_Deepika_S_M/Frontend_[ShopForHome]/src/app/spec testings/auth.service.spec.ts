// import { TestBed } from '@angular/core/testing';
// import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
// import { AuthService } from '../services/auth.service';

// describe('AuthService', () => {
//   let service: AuthService;
//   let httpMock: HttpTestingController;

//   beforeEach(() => {
//     TestBed.configureTestingModule({
//       imports: [HttpClientTestingModule],
//       providers: [AuthService],
//     });
//     service = TestBed.inject(AuthService);
//     httpMock = TestBed.inject(HttpTestingController);
//     localStorage.clear();
//   });

//   afterEach(() => {
//     httpMock.verify();
//     localStorage.clear();
//   });

//   it('should be created', () => {
//     expect(service).toBeTruthy();
//   });

//   it('should login and store user in localStorage', () => {
//     const mockUser = { email: 'test@example.com', role: 'admin', token: 'abcd1234' };
//     const payload = { email: 'test@example.com', password: '123456' };

//     service.login(payload).subscribe((res) => {
//       expect(res).toEqual(mockUser);
//       expect(localStorage.getItem('user')).toBe(JSON.stringify(mockUser));
//     });

//     const req = httpMock.expectOne('http://localhost:5000/api/auth/login');
//     expect(req.request.method).toBe('POST');
//     req.flush(mockUser);
//   });

//   it('should register a user', () => {
//     const mockResponse = { message: 'User registered successfully' };
//     const payload = { fullName: 'Test User', email: 'test@example.com', password: '123456' };

//     service.register(payload).subscribe((res) => {
//       expect(res).toEqual(mockResponse);
//     });

//     const req = httpMock.expectOne('http://localhost:5000/api/auth/register');
//     expect(req.request.method).toBe('POST');
//     req.flush(mockResponse);
//   });

//   it('should return user role if logged in', () => {
//     const mockUser = { email: 'test@example.com', role: 'admin' };
//     localStorage.setItem('user', JSON.stringify(mockUser));

//     expect(service.getUserRole()).toBe('admin');
//   });

//   it('should return empty string if no user is logged in', () => {
//     expect(service.getUserRole()).toBe('');
//   });

//   it('should remove user from localStorage on logout', () => {
//     const mockUser = { email: 'test@example.com', role: 'admin' };
//     localStorage.setItem('user', JSON.stringify(mockUser));

//     service.logout();
//     expect(localStorage.getItem('user')).toBeNull();
//   });

//   it('should return true if user is logged in', () => {
//     localStorage.setItem('user', JSON.stringify({ email: 'test@example.com' }));
//     expect(service.isLoggedIn()).toBeTrue();
//   });

//   it('should return false if user is not logged in', () => {
//     expect(service.isLoggedIn()).toBeFalse();
//   });
// });
