import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

const oAuthConfig = {
  issuer: 'https://localhost:44321/',
  redirectUri: baseUrl,
  clientId: 'PasswordlessAuthenticationApplication_App',
  responseType: 'code',
  scope: 'offline_access PasswordlessAuthenticationApplication',
  requireHttps: true,
};

export const environment = {
  production: true,
  application: {
    baseUrl,
    name: 'PasswordlessAuthenticationApplication',
  },
  oAuthConfig,
  apis: {
    default: {
      url: 'https://localhost:44321',
      rootNamespace: 'PasswordlessAuthenticationApplication',
    },
    AbpAccountPublic: {
      url: oAuthConfig.issuer,
      rootNamespace: 'AbpAccountPublic',
    },
  },
  remoteEnv: {
    url: '/getEnvConfig',
    mergeStrategy: 'deepmerge'
  }
} as Environment;
