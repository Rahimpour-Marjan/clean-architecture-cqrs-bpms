import styled, { css } from 'styled-components';

export const Input = styled.input`
  border: 1px solid var(--primary-800);
  background-color: var(--white);
  border-radius: var(--border-radius-4);
  color: var(--grey-500);
  padding: 1rem;
  width: 25rem;

  ${props =>
    props.hasError &&
    css`
      border: 1px solid var(--red-dark);
      background-color: var(--red-light);
      color: var(--red-dark);
    `}
  ${props =>
    props.disabled &&
    css`
      border: 1px solid var(--grey-300);
      background-color: var(--grey-200);
    `}
`;
