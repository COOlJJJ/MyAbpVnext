import request from '@/utils/request'
import qs from 'querystring'

export function login(data) {
  return request({
    baseURL: 'https://localhost:44316',
    url: '/connect/token',
    method: 'post',
    headers: { 'content-type': 'application/x-www-form-urlencoded' },
    data: qs.stringify(data)
  })
}

export function getInfo() {
  return request({
    url: '/api/account/my-profile',
    method: 'get'
  })
}

export function changePassword(data) {
  return request({
    url: '/api/account/my-profile/change-password',
    method: 'post',
    data: data
  })
}

export function setUserInfo(data) {
  return request({
    url: '/api/account/my-profile',
    method: 'put',
    data: data
  })
}

