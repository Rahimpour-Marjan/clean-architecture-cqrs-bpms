import styled from 'styled-components';
import { LoginForm } from './LoginForm';

const RegistrationStyled = styled.div`
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  width: 100dvw;
  height: 100dvh;
  background-color: var(--primary-900);

  .login-form {
    background-color: var(--white);
    padding: 2rem;
    border-radius: var(--border-radius-4);
  }
`;

export const Login = () => {
  return (
    <RegistrationStyled>
      <LoginForm title='Sign In' />
    </RegistrationStyled>
  );
};
