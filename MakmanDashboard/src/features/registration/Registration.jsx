import styled from 'styled-components';
import { RegistrationForm } from './RegistrationForm';

const RegistrationStyled = styled.div`
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  width: 100dvw;
  height: 100dvh;
  background-color: var(--primary-900);

  .registration-form {
    background-color: var(--white);
    padding: 2rem;
    border-radius: var(--border-radius-4);

    display: grid;
    grid-template-columns: repeat(2, 1fr);
    grid-template-rows: repeat(7, 1fr);

    div {
      &:nth-of-type(5) {
        grid-column-start: 1;
        grid-column-end: -1;
      }

      &:nth-of-type(1),
      &:nth-of-type(2),
      &:nth-of-type(8),
      &:nth-of-type(9) {
        align-items: center;
        grid-column-start: 1;
        grid-column-end: -1;
      }
    }
  }
`;

export const Registration = () => {
  return (
    <RegistrationStyled>
      <RegistrationForm title='Sign Up' />
    </RegistrationStyled>
  );
};
