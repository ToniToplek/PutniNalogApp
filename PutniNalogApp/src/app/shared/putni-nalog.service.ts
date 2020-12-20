import { Injectable } from '@angular/core';
import { Auto, Korisnici, Lokacija, PutniNalog } from './putni-nalog.model';
import { HttpClient } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class PutniNalogService {

  constructor(private http: HttpClient) { }

  formData: PutniNalog = new PutniNalog();
  fromDataLokacija: Lokacija = new Lokacija();
  fromDataKorisnici: Korisnici = new Korisnici();
  fromDataAuto: Auto = new Auto();

  list: PutniNalog[];
  listLokacija: Lokacija[];
  listPutnika: Korisnici[];
  listAuto: Auto[];


  readonly baseURL = 'http://localhost:60970/api/PutniNalog'
  readonly baseURLLokacija = 'http://localhost:60970/api/Lokacije'
  readonly baseURLPutnici = 'http://localhost:60970/api/Korisnici'
  readonly baseURLAuto = 'http://localhost:60970/api/Auti'

  postPutniNalog() {
    return this.http.post(this.baseURL, this.formData);
  }
  postLokacija() {
    return this.http.post(this.baseURLLokacija, this.fromDataLokacija);
  }
  postPutnik() {
    return this.http.post(this.baseURLPutnici, this.fromDataKorisnici);
  }
  postAuto() {
    return this.http.post(this.baseURLAuto, this.fromDataAuto);
  }


  putPutniNalog() {
    return this.http.put(`${this.baseURL}/${this.formData.idPutniNalog}`, this.formData);
  }
  putLokacija() {
    return this.http.put(`${this.baseURLLokacija}/${this.fromDataLokacija.idLokacija}`, this.fromDataLokacija);
  }
  putPutnik() {
    return this.http.put(`${this.baseURLPutnici}/${this.fromDataKorisnici.idKorisnik}`, this.fromDataKorisnici);
  }
  putAuto() {
    return this.http.put(`${this.baseURLAuto}/${this.fromDataAuto.idAuto}`, this.fromDataAuto);
  }

  deletePutniNalog(id: number) {
    return this.http.delete(`${this.baseURL}/${id}`);
  }
  deleteLokacija(id: number) {
    return this.http.delete(`${this.baseURLLokacija}/${id}`);
  }
  deletePutnik(id: number) {
    return this.http.delete(`${this.baseURLPutnici}/${id}`);
  }
  deleteAuto(id: number) {
    return this.http.delete(`${this.baseURLAuto}/${id}`);
  }

  refreshList() {
    this.http.get(this.baseURL)
      .toPromise()
      .then(res => this.list = res as PutniNalog[]);
  }
  refreshListLokacija() {
    this.http.get(this.baseURLLokacija)
      .toPromise()
      .then(res => this.listLokacija = res as Lokacija[]);
  }
  refreshListPutnik() {
    this.http.get(this.baseURLPutnici)
      .toPromise()
      .then(res => this.listPutnika = res as Korisnici[]);
  }

  refreshListAuto() {
    this.http.get(this.baseURLAuto)
      .toPromise()
      .then(res => this.listAuto = res as Auto[]);
  }

}
