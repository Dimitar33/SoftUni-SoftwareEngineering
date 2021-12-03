
import * as api from './api.js';

export const login = api.login;
export const register = api.register;
export const logout = api.logout;

export async function getAllCars(){

    return await api.get(`/data/cars?sortBy=_createdOn%20desc`);
}

export async function createCar(car){

    return await api.post(`/data/cars`, car);
}

export async function getCar(id){

    return await api.get(`/data/cars/${id}`);
}

export async function editCar(id, car){

    return await api.put(`/data/cars/${id}`, car);
}

export async function deleteCar(id){

    return await api.del(`/data/cars/${id}`)
}

export async function myCars(userId){

    return await api.get(`/data/cars?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`);
}

export async function getByYear(query){

    return await api.get(`/data/cars?where=year%3D${query}`);
}