import { Component } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  suggestedPassword: string ="";
  email: string | undefined;
  username: string | undefined;
  judet: string |undefined;
  cnp: string|undefined;
  passwd:string|undefined;
  useSuggested: boolean = false;
  showSuggestedPassword: boolean = false;
showUseSuggestedMessage: any;
otpValid: boolean = true;

  constructor(private http: HttpClient) {}

  getSuggestedPassword() {
    this.http.get<any>('https://localhost:7012/OTP/generate').subscribe(
      response => {
        this.suggestedPassword = response.otp; 
      },
      error => {
        console.error('Error:', error);
      }
    );
  }


  validateOTP(otp: string): Observable<boolean> {
    const url = `https://localhost:7012/OTP/validate`;
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.post<boolean>(url, otp, { headers });
  }


  useSuggestedPassword() {
    if(this.validateOTP(this.suggestedPassword)){
    this.passwd = this.suggestedPassword;
    this.otpValid = false;
    }
  }

  resetFields() {
    if(this.email && this.username && this.passwd && this.validateEmail()){
         this.email = '';
    this.username = '';
    this.passwd = '';
    }
    this.otpValid = false;
 
  }
  

  validateEmail() {
    // Utilizăm o expresie regulată pentru a verifica dacă adresa de email conține caracterul '@'
    if (this.email !== undefined) {
      const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
      return emailRegex.test(this.email);
    }
    return false; 
  }
  

}
