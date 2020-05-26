const ENV = {
  dev: {
    apiUrl: 'http://localhost:44348',
    oAuthConfig: {
      issuer: 'http://localhost:44348',
      clientId: 'MoCRM_App',
      clientSecret: '1q2w3e*',
      scope: 'MoCRM',
    },
    localization: {
      defaultResourceName: 'MoCRM',
    },
  },
  prod: {
    apiUrl: 'http://localhost:44348',
    oAuthConfig: {
      issuer: 'http://localhost:44348',
      clientId: 'MoCRM_App',
      clientSecret: '1q2w3e*',
      scope: 'MoCRM',
    },
    localization: {
      defaultResourceName: 'MoCRM',
    },
  },
};

export const getEnvVars = () => {
  // eslint-disable-next-line no-undef
  return __DEV__ ? ENV.dev : ENV.prod;
};
