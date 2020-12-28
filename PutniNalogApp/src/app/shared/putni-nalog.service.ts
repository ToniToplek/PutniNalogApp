import { Injectable } from '@angular/core';
import { Auto, Korisnici, Lokacija, PutniNalog, KorisniciNalog } from './putni-nalog.model';
import { HttpClient } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class PutniNalogService {

  constructor(private http: HttpClient) { }

  formData: PutniNalog = new PutniNalog();
  formDataLokacija: Lokacija = new Lokacija();
  formDataKorisnici: Korisnici = new Korisnici();
  formDataAuto: Auto = new Auto();
  formDataKorisniciNalog: KorisniciNalog = new KorisniciNalog();

  list: PutniNalog[];
  listLokacija: Lokacija[];
  listPutnika: Korisnici[];
  listAuto: Auto[];
  listKorisniciNalog: KorisniciNalog[];

  readonly baseURL = 'http://localhost:60970/api/PutniNalog'
  readonly baseURLLokacija = 'http://localhost:60970/api/Lokacije'
  readonly baseURLPutnici = 'http://localhost:60970/api/Korisnici'
  readonly baseURLAuto = 'http://localhost:60970/api/Auti'
  readonly baseURLKorisniciNalog = 'http://localhost:60970/api/KorisniciNalog'

  postPutniNalog() {
    return this.http.post(this.baseURL, this.formData);
  }
  postLokacija() {
    return this.http.post(this.baseURLLokacija, this.formDataLokacija);
  }
  postPutnik() {
    return this.http.post(this.baseURLPutnici, this.formDataKorisnici);
  }
  postAuto() {
    return this.http.post(this.baseURLAuto, this.formDataAuto);
  }
  postKorisniciNalog() {
    return this.http.post(this.baseURLKorisniciNalog, this.formDataKorisniciNalog);
  }

  putPutniNalog() {
    return this.http.put(`${this.baseURL}/${this.formData.idPutniNalog}`, this.formData);
  }
  putLokacija() {
    return this.http.put(`${this.baseURLLokacija}/${this.formDataLokacija.idLokacija}`, this.formDataLokacija);
  }
  putPutnik() {
    return this.http.put(`${this.baseURLPutnici}/${this.formDataKorisnici.idKorisnik}`, this.formDataKorisnici);
  }
  putAuto() {
    return this.http.put(`${this.baseURLAuto}/${this.formDataAuto.idAuto}`, this.formDataAuto);
  }
  putKorisniciNalog() {
    return this.http.put(`${this.baseURLKorisniciNalog}/${this.formDataKorisniciNalog.idKorisniciNalog}`, this.formDataKorisniciNalog);
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
  deleteKorisniciNalog(id: number) {
    return this.http.delete(`${this.baseURLKorisniciNalog}/${id}`);
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

  refreshListKorisniciNalog() {
    this.http.get(this.baseURLKorisniciNalog)
      .toPromise()
      .then(res => this.listKorisniciNalog = res as KorisniciNalog[]);
  }

}
