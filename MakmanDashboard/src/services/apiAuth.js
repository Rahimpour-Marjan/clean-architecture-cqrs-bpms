import SING_IN_RES from '../data/sign-in.json';
import { mockFetch } from '../utils/mockFetch';

export const signup = async signupBody => {
  // await post('user/sign-up', signupBody);

  const res = await mockFetch({});

  return res;
};

export const login = async singingBody => {
  // const res = await post('user/sign-in', singingBody);

  await mockFetch({});

  const res = SING_IN_RES;

  return res;
};

export const logout = async () => {
  await mockFetch({});
};
