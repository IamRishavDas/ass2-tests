 import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

const oAuthConfig = {
  issuer: 'https://localhost:44349/',
  redirectUri: baseUrl,
  clientId: 'PasswordlessAuthApp_App',
  responseType: 'code',
  scope: 'offline_access PasswordlessAuthApp',
  requireHttps: true,
};

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'PasswordlessAuthApp',
  },
  oAuthConfig,
  apis: {
    default: {
      url: 'https://localhost:44349',
      rootNamespace: 'PasswordlessAuthApp',
    },
    AbpAccountPublic: {
      url: oAuthConfig.issuer,
      rootNamespace: 'AbpAccountPublic',
    },
  },
} as Environment;
